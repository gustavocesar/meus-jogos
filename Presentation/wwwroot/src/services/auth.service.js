import Environment from "../base/environment.js";

export default class AuthService {
  static login(username, password) {
    return new Promise(function (resolve, reject) {
      let env = new Environment();

      let ajaxReq = $.ajax({
        url: `${env.api}/${env.login}`,
        type: "POST",
        method: "POST",
        data: JSON.stringify({
          username: username,
          password: password,
        }),
        crossDomain: true,
        dataType: "json",
        contentType: "application/json",
        beforeSend: function () {},
        success: function (data) {
          resolve(data);
        },
        error: function (e) {
          reject(e);
        },
        complete: function () {},
      });
    });
  }
}
