import env from "./../../environments/environments";

import axios from "axios";

export default class AuthService {
  static redirectLogin() {
    window.location = `${env.auth.baseUrlAuth}${env.auth.endPointLogin}`;
    return;
  }

  static logout() {
    localStorage.clear();
    window.location = `${env.auth.baseUrlAuth}${env.auth.endPointLogout}`;
    return;
  }

  static isAuth() {
    return AuthService.getUserAuth() != null;
  }

  static async loginByAuthorizationCode(code) {
    const response = await axios.post(`${env.meusJogos.baseApi}/auth`, code);

    if (response.status == 200) {
      AuthService.saveUserAuth(response.data);
    }

    return response;
  }

  // static async refreshToken() {
  //   var user = AuthService.getUserAuth();

  //   const response = await axios.post(
  //     `${env.meusJogos.baseApi}/auth/refresh-token`,
  //     {
  //       refreshToken: user.refreshToken,
  //     }
  //   );

  //   if (response.status == 200) {
  //     AuthService.saveUserAuth(response.data);
  //   }

  //   return response;
  // }

  static saveUserAuth(userAuth) {
    localStorage.setItem("userAuth", JSON.stringify(userAuth));
  }

  static getUserAuth() {
    return JSON.parse(localStorage.getItem("userAuth"));
  }

  static getAvatar() {
    var user = AuthService.getUserAuth();
    if (user) {
      return user.foto;
    }
    return "";
  }
}
