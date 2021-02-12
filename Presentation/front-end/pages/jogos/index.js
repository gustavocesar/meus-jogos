import React, { useState, useEffect } from "react";
import { Row, Col } from "react-bootstrap";

import Layout from "../../layout";
import JogoService from "../../services/jogo-service";
import CardJogo from "./card";

export default function Jogos() {
  const [jogos, setJogos] = useState([]);
  const jogoService = new JogoService();

  useEffect(() => {
    updateGrid();
  }, []);

  const fetchAll = async () => {
    try {
      let response = await jogoService.get("jogos");
      if (response && response.status === 200) {
        return response.data;
      }
    } catch (error) {
      console.log("catch", error);
    }
  };

  const updateGrid = () =>
    fetchAll().then((a) => {
      setJogos(a);
    });

  return (
    <Layout>
      <h1 className="text-center">Jogos</h1>
      <hr />
      <Row>
        {jogos &&
          jogos.map((jogo, key) => (
            <>
              <Col style={{ marginBottom: "15px" }}>
                <CardJogo jogo={jogo} />{" "}
              </Col>
            </>
          ))}
      </Row>
    </Layout>
  );
}
