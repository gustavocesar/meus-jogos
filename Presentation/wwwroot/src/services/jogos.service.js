import Environment from "../base/environment.js";

export default class JogoService {
  static getJogos() {
    return new Promise(function (resolve, reject) {
      let env = new Environment();

      let ajaxReq = $.ajax({
        url: `${env.api}/${env.jogos}`,
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

  static getJogo(id) {
    return new Promise(function (resolve, reject) {
      let env = new Environment();

      let ajaxReq = $.ajax({
        url: `${env.api}/${env.jogos}/${id}`,
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
  
  static incluir(titulo, plataforma) {
    return new Promise(function (resolve, reject) {
      let env = new Environment();

      let ajaxReq = $.ajax({
        url: `${env.api}/${env.jogos}`,
        type: "POST",
        method: "POST",
        crossDomain: true,
        data: JSON.stringify({
          titulo: titulo,
          plataforma: plataforma,
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

  static editar(id, titulo, plataforma) {
    return new Promise(function (resolve, reject) {
      let env = new Environment();

      let ajaxReq = $.ajax({
        url: `${env.api}/${env.jogos}`,
        type: "PUT",
        method: "PUT",
        crossDomain: true,
        data: JSON.stringify({
          id: id,
          titulo: titulo,
          plataforma: plataforma,
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
