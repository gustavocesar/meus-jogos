import { Card, Button } from "react-bootstrap";

export default function CardJogo(props) {
  const { jogo } = props;
  return (
    <Card className="text-center" style={{ width: "18rem" }}>
      <Card.Body>
        <Card.Title>{jogo.titulo}</Card.Title>
        <Card.Subtitle className="mb-2 text-muted">
          {jogo.plataforma}
        </Card.Subtitle>

        <hr />

        <Button variant="primary">Editar</Button>
      </Card.Body>
    </Card>
  );
}
