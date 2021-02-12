import Layout from "../../layout";
import { Form, Button, Row } from "react-bootstrap";

import LoginService from "../../services/login-service";
import AuthService from "../../services/auth/auth-service";

export default function Login() {
  const loginService = new LoginService();

  const login = async (event) => {
    event.preventDefault();
    const { username, password } = event.target;
    let user = {
      username: username.value,
      password: password.value,
    };

    loginService
      .post("auth/login", user)
      .then((r) => {
        if (r && r.status === 200) {
          AuthService.saveUserAuth(r.data);
          window.location = "/";
        }
        console.log("THEN", r);
      })
      .catch((e) => {
        console.log("CATCH", e);
      });
  };

  return (
    <Layout>
      <h1 className="text-center">Login</h1>
      <hr />
      <Row>
        <Form onSubmit={login}>
          <Form.Group controlId="formBasicEmail">
            <Form.Label>Usuário</Form.Label>
            <Form.Control
              name="username"
              type="text"
              placeholder=""
              value="admin" //TODO: remover o valor fixo
            />
          </Form.Group>

          <Form.Group controlId="formBasicPassword">
            <Form.Label>Senha</Form.Label>
            <Form.Control
              name="password"
              type="password"
              placeholder=""
              value="123456" //TODO: remover o valor fixo
            />
          </Form.Group>
          <Button variant="primary" type="submit">
            Submit
          </Button>
        </Form>
      </Row>
    </Layout>
  );
}
