import { Card, Button } from "react-bootstrap";

export default function CardAmigo(props) {
  const { amigo } = props;
  return (
    <Card className="text-center" style={{ width: "18rem" }}>
      <Card.Body>
        <Card.Title>{amigo.nome}</Card.Title>
        <Card.Subtitle className="mb-2 text-muted">
          {amigo.celular}
        </Card.Subtitle>

        <hr />

        <Button variant="primary">Editar</Button>
      </Card.Body>
    </Card>
  );
}
