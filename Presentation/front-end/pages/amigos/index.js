import React, { useState, useEffect } from "react";
import Layout from "../../layout";
import AmigoService from "../../services/amigo-service";

export default function Amigos() {
  const [amigos, setAmigos] = useState([]);
  const amigoService = new AmigoService();

  useEffect(() => {
    updateGrid();
  }, []);

  const fetchAll = async () => (await amigoService.get("/amigos")).data;

  const updateGrid = () =>
    fetchAll().then((a) => {
      console.log(a);
      setAmigos(a);
    });

  return (
    <Layout>
      <h1>Amigos</h1>
    </Layout>
  );
}
