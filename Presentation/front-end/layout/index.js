import Head from "next/head";
import Footer from "./footer";
import Menu from "./menu";
import "bootstrap/dist/css/bootstrap.min.css";
import { Row } from "react-bootstrap";

export default function Layout({ children }) {
  return (
    <div className="container">
      <Head>
        <title>Meus Jogos</title>
        <link rel="icon" href="/icons/iconfinder_multimedia-19_809511.ico" />
      </Head>

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

        {children}
      </main>

      <Footer />
    </div>
  );
}
