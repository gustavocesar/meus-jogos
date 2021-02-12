import React, { useState, useEffect } from "react";

import Head from "next/head";
import Footer from "./footer";
import Menu from "./menu";
import Interceptor from "../services/auth/interceptor";

import { Container, Row } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";

export default function Layout({ children }) {
  const [load, setLoad] = useState(false);

  return (
    <div className="container">
      <Head>
        <title>Meus Jogos</title>
        <link rel="icon" href="/icons/iconfinder_multimedia-19_809511.ico" />
      </Head>

      <Interceptor setLoad={setLoad} load={load} />

      <main>
        <Row>
          <h2>
            <img
              src="/icons/iconfinder_multimedia-19_809511.svg"
              alt="Logo"
              className="logo"
            />
            &nbsp;Meus Jogos
          </h2>
        </Row>

        <hr />

        <Menu />

        <hr />

        <Container>{children}</Container>
      </main>

      <Footer />
    </div>
  );
}
