import React, { useState, useEffect } from "react";
import { Row, Col } from "react-bootstrap";

import Layout from "../../layout";
import AmigoService from "../../services/amigo-service";
import CardAmigo from "./card";

export default function Amigos() {
  const [amigos, setAmigos] = useState([]);
  const amigoService = new AmigoService();

  useEffect(() => {
    updateGrid();
  }, []);

  const fetchAll = async () => {
    try {
      let response = await amigoService.get("amigos");
      if (response && response.status === 200) {
        return response.data;
      }
    } catch (error) {
      console.log("catch", error);
    }
  };

  const updateGrid = () =>
    fetchAll().then((a) => {
      setAmigos(a);
    });

  return (
    <Layout>
      <h1 className="text-center">Amigos</h1>
      <hr />
      <Row>
        {amigos &&
          amigos.map((amigo, key) => (
            <>
              <Col style={{ marginBottom: "15px" }}>
                <CardAmigo amigo={amigo} />{" "}
              </Col>
            </>
          ))}
      </Row>
    </Layout>
  );
}
