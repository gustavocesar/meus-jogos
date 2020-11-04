import Environment from "../base/environment.js";

export default class EmprestimoService {
  static getJogosDisponiveis() {
    return new Promise(function (resolve, reject) {
      let env = new Environment();

      let ajaxReq = $.ajax({
        url: `${env.api}/${env.emprestimos}/get-jogos-disponiveis`,
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

  static getJogosEmprestados() {
    return new Promise(function (resolve, reject) {
      let env = new Environment();

      let ajaxReq = $.ajax({
        url: `${env.api}/${env.emprestimos}/get-jogos-emprestados`,
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

  static emprestar(jogoId, amigoId) {
    return new Promise(function (resolve, reject) {
      let env = new Environment();

      let ajaxReq = $.ajax({
        url: `${env.api}/${env.emprestimos}`,
        type: "POST",
        method: "POST",
        crossDomain: true,
        data: JSON.stringify({
          jogoId: jogoId,
          amigoId: amigoId,
        }),
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