import Link from "next/link";
import { Container, Row, Col } from "react-bootstrap";

export default function Menu() {
  return (
    <Container>
      <Row className="justify-content-md-center">
        <Col>
          <Link href="/">
            <a>
              <strong>Home</strong>
            </a>
          </Link>
        </Col>
        <Col>
          <Link href="/amigos">
            <a>Amigos</a>
          </Link>
        </Col>
        <Col>
          <Link href="/jogos">
            <a>Jogos</a>
          </Link>
        </Col>
        <Col>
          <Link href="/emprestimos">
            <a>Empréstimos</a>
          </Link>
        </Col>
      </Row>
    </Container>
  );
}
