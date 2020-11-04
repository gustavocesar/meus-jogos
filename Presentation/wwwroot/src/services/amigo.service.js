import Environment from "../base/environment.js";

export default class AmigoService {
  static getAmigos() {
    return new Promise(function (resolve, reject) {
      let env = new Environment();

      let ajaxReq = $.ajax({
        url: `${env.api}/${env.amigos}`,
        type: "GET",
        method: "GET",
        crossDomain: true,
        dataType: "json",
        contentType: "application/json",
        beforeSend: function (xhr) {
          xhr.setRequestHeader(
            "Authorization",
            "Bearer " + localStorage.getItem("meus-jogos-token")
          );
        },
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