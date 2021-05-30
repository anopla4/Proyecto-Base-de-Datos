import React, { Component } from "react";
import {
  Container,
  Card,
  ListGroup,
  ListGroupItem,
  CardDeck,
  Row,
  Col,
  Button,
  Navbar,
  Nav,
  Form,
  Image,
} from "react-bootstrap";
import "../../containers/App/App.css";
import DeleteEdit from "../../components/DeleteEdit/DeleteEdit";
import Add from "../../components/Add/Add";

class Teams extends Component {
  state = {
    addTeam: false,
    editTeam: false,
    teamEdit: {},
    colors: [
      "Negro",
      "Azul",
      "Marrón",
      "Gris",
      "Verde",
      "Naranja",
      "Rosa",
      "Púrpura",
      "Rojo",
      "Blanco",
      "Amarillo",
    ],
    teams: [],
    // teams: [
    //   {
    //     id: 1,
    //     name: "Matanzas",
    //     color: "Rojo",
    //     initials: "MTN",
    //     img: "http://localhost:8000/src/logos/matanzas.png",
    //   },
    //   {
    //     id: 2,
    //     name: "Pinar del Río",
    //     color: "Verde",
    //     initials: "PR",
    //     img: "http://localhost:8000/src/logos/pinar-del-rio.jpg",
    //   },
    //   {
    //     id: 3,
    //     name: "Industriales",
    //     color: "Azul",
    //     initials: "IND",
    //     img: "http://localhost:8000/src/logos/industriales.png",
    //   },
    //   {
    //     id: 4,
    //     name: "Cienfuegos",
    //     color: "Verde",
    //     initials: "CFG",
    //     img: "http://localhost:8000/src/logos/cienfuegos.png",
    //   },
    // ],
  };

  componentDidMount() {
    fetch("https://localhost:44334/api/Team", { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ teams: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
  }

  handleOnClick = (idT) => {
    this.props.history.push({ pathname: "/team", state: { idTeam: idT } });
  };

  handleAddClick = () => {
    this.setState({ addTeam: true, editTeam: false, teamEdit: {} });
  };

  handleEditClick = (team) => {
    this.setState({ addTeam: false, editTeam: true, teamEdit: team });
  };

  handleCloseAdd = () => {
    this.setState({ editTeam: false, addTeam: false, teamEdit: {} });
  };

  handleOnDelete = (id, index) => {
    fetch(`https://localhost:44334/api/Team/${id}`, {
      mode: "cors",
      method: "DELETE",
    })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });

    let n_teams = [...this.state.teams];
    n_teams.splice(index, 1);

    this.setState({ series: n_teams });
  };

  onFormSubmit = (e) => {
    let formElements = e.target.elements;
    const name = formElements.name.value;
    const initials = formElements.initials.value;
    const color = formElements.color.value;

    let team = {
      name,
      initials,
      color,
    };

    let postUrl =
      "https://localhost:44334/api/Team" +
      (this.state.editTeam ? `/${this.state.teamEdit.id}` : "");
    fetch(postUrl, {
      mode: "cors",
      headers: { "Content-Type": "application/json" },
      method: this.state.editTeam ? "PATCH" : "POST",
      body: JSON.stringify(team),
    })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    this.setState({ addTeam: false, editTeam: false });
  };

  render() {
    return (
      <Container>
        <h1 className="mb-5 my-style-header">Equipos de béisbol</h1>
        <Row className="mb-4">
          <Col>
            <Add text="Agregar equipo" onClick={this.handleAddClick} />
          </Col>
        </Row>
        <Row>
          <Col>
            <CardDeck>
              {this.state.teams.map((team, index) => (
                <Col>
                  <Card
                    className="mb-3"
                    key={team.id}
                    style={{ width: "18rem" }}
                    border="primary"
                  >
                    <Card.Img height="250vw" variant="top" src={team.img} />
                    <Card.Body>
                      <Card.Title>{team.initials}</Card.Title>
                      <Card.Subtitle>{team.name}</Card.Subtitle>
                    </Card.Body>
                    <ListGroup className="list-group-flush">
                      <ListGroupItem>Color: {team.color}</ListGroupItem>
                    </ListGroup>
                    <Card.Body>
                      <Card.Link
                        href="/team"
                        onClick={() => this.handleOnClick(team.id)}
                      >
                        Saber más
                      </Card.Link>
                      <DeleteEdit
                        delete={true}
                        onDelete={() => this.handleOnDelete(team.id, index)}
                        edit={true}
                        onEdit={() => this.handleEditClick(team)}
                      />
                    </Card.Body>
                  </Card>
                </Col>
              ))}
            </CardDeck>
          </Col>

          {(this.state.addTeam || this.state.editTeam) && (
            <Col md={3}>
              <Navbar fixed="right">
                <Nav.Item>
                  <Form
                    key={this.state.teamEdit.id}
                    onSubmit={this.onFormSubmit}
                  >
                    <Form.Group controlId="name">
                      <Form.Label>Nombre:</Form.Label>
                      <Form.Control
                        type="text"
                        defaultValue={
                          this.state.editTeam ? this.state.teamEdit.name : ""
                        }
                      />
                    </Form.Group>
                    <Form.Group>
                      <Image src={this.state.teamEdit.img} />
                      <Form.File id="img" label="Logo del equipo" />
                    </Form.Group>
                    <Form.Group controlId="initials">
                      <Form.Label>Iniciales:</Form.Label>
                      <Form.Control
                        type="text"
                        defaultValue={
                          this.state.editTeam
                            ? this.state.teamEdit.initials
                            : ""
                        }
                      />
                    </Form.Group>
                    <Form.Group controlId="color">
                      <Form.Label>Color:</Form.Label>
                      <Form.Control
                        as="select"
                        defaultValue={
                          this.state.editTeam ? this.state.teamEdit.color : ""
                        }
                        custom
                      >
                        <option>{""}</option>
                        {this.state.colors.map((col) => (
                          <option>{col}</option>
                        ))}
                      </Form.Control>
                    </Form.Group>
                    <Button
                      className="mr-2"
                      style={{ float: "left" }}
                      variant="primary"
                      type="submit"
                    >
                      Aceptar
                    </Button>
                    <Button
                      style={{ float: "right" }}
                      onClick={this.handleCloseAdd}
                      variant="secondary"
                    >
                      Cancelar
                    </Button>
                  </Form>
                </Nav.Item>
              </Navbar>
            </Col>
          )}
        </Row>
      </Container>
    );
  }
}

export default Teams;
