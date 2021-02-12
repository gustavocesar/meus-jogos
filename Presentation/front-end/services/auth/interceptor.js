import React from "react";
import axios from "axios";
import { toast } from "react-toastify";

import AuthService from "./auth-service";
import env from "./../../environments/environments";

const Interceptor = (props) => {
  const { setLoad } = props;

  const notAuthUrl = (url) => {
    let notAuth = false;
    for (let endpoint of env.auth.routerNotAuth) {
      if (url.toLowerCase().startsWith(env.meusJogos.baseApi + endpoint)) {
        notAuth = true;
      }
    }
    return notAuth;
  };

  const loading = (config, status) => {
    if (config && (config.spinner == undefined || config.spinner === true)) {
      setLoad(status);
      return;
    }
  };

  const toastError = (data, status, flagToast) => {
    if (status === 400 && (flagToast == undefined || flagToast === true)) {
      if (data.content.length > 0) {
        data.content.forEach((e) => toast.error(e.message.join(" ")));
      }
      return;
    }

    if (flagToast == undefined || flagToast === true) {
      toast.error(
        "Ocorreu um erro não esperado ao tentar processar sua requisição. Por favor, atualize a página e tente novamente."
      );
    }
  };

  axios.interceptors.request.use(async function (config) {
    loading(config, true);

    if (!notAuthUrl(config.url)) {
      let auth = AuthService.getUserAuth();

      if (auth && auth.accessToken) {
        config.headers.Authorization = `Bearer ${auth.accessToken}`;
      }
    }
    return config;
  });

  axios.interceptors.response.use(
    async function (response) {
      setLoad(false);
      return response;
    },
    async function (error) {
      setLoad(false);

      const {
        config,
        response: { status, data },
      } = error;

      const originalRequest = config;

      if (status === 401 && !notAuthUrl(config.url)) {
        //   let response = await AuthService.refreshToken();

        //   if (response.status === 200) {
        //     const retryOriginalRequest = new Promise((resolve) => {
        //       resolve(axios(originalRequest));
        //     });

        //     return retryOriginalRequest;
        //   } else {
        AuthService.redirectLogin();
        //   }
      }

      if (status === 400 || status > 401) {
        toastError(data, status, config.toast);

        return;
      }

      return Promise.reject(error);
    }
  );

  return <></>;
};

export default Interceptor;
