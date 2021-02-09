import axios from "axios";
import env from "./../../environments/environments";

class ServiceBase {
  serialize(data) {
    return `${Object.keys(data)
      .map((k) => encodeURIComponent(k) + "=" + encodeURIComponent(data[k]))
      .join("&")}`;
  }

  trySerialize = (qs) => (qs ? this.serialize(qs) : "");

  async get(endpoint, qs = null, spinner = true, toast = true) {
    const queryString = this.trySerialize(qs);

    return axios.get(`${env.meusJogos.baseApi}${endpoint}?${queryString}`, {
      spinner,
      toast,
    });
  }

  async post(endpoint, data, qs = null, spinner = true, header = null) {
    const queryString = this.trySerialize(qs);

    return axios.post(
      `${env.meusJogos.baseApi}${endpoint}?${queryString}`,
      data,
      { header, spinner }
    );
  }

  async put(endpoint, data, qs = null, spinner = true) {
    const queryString = this.trySerialize(qs);

    return axios.put(
      `${env.meusJogos.baseApi}${endpoint}?${queryString}`,
      data,
      { spinner }
    );
  }
}

export default ServiceBase;
