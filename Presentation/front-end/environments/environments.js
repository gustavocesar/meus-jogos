const environment = {
  meusJogos: {
    baseApi: "https://localhost:5001/v1/",
  },
  auth: {
    baseUrlAuth: "http://localhost:3000/",
    // baseUrlAuth: "https://authhomol.sescgo.com.br/",
    endPointLogin: "login",
    endPointLogout: "logout",
    // clientId: "pcg",
    // responseType: "code",
    // scope: "offline_access",
    // logoutUrl: "http://localhost:8080",
    routerNotAuth: ["/auth", "/auth/refresh-token"],
  },
};

export default environment;
