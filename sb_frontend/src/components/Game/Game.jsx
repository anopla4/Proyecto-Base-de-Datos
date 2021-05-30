import React, { Component } from "react";
import "./Game.css";
import {
  Container,
  Row,
  Col,
  Image,
  Card,
  Nav,
  Table,
  Button,
  Navbar,
  Form,
} from "react-bootstrap";
import Players from "../../components/Players/Players";
import arrow from "../../static/arrow-left.svg";
import Add from "../../components/Add/Add";
import DeleteEdit from "../../components/DeleteEdit/DeleteEdit";

class Game extends Component {
  state = {
    page: 1,
    addPlayer: false,
    typeTeam: "",
    addChange: false,
    playersWinnerGame: [
      {
        id: 1,
        name: "Alexander Malleta",
        position: [{ positionName: "Primera base" }],
        img: "http://localhost:8000/src/logos/malleta.jpg",
        age: 44,
        teams: ["Industriales", "Metropolitano"],
        current_Team: "Retirado",
        year_Experience: 20,
        position_Average: 301,
      },
      {
        id: 2,
        name: "Frank Camilo Morejón",
        position: [{ positionName: "Catcher" }],
        img: "http://localhost:8000/src/logos/frank-camilo.jpg",
        age: 44,
        teams: ["Industriales"],
        current_Team: "Retirado",
        year_Experience: 17,
        position_Average: 253,
      },
    ],
    playersLoserGame: [
      {
        id: 1,
        name: "Alexander Malleta",
        position: [{ positionName: "Primera base" }],
        img: "http://localhost:8000/src/logos/malleta.jpg",
        age: 44,
        teams: ["Industriales", "Metropolitano"],
        current_Team: "Retirado",
        year_Experience: 20,
        position_Average: 301,
      },
      {
        id: 2,
        name: "Frank Camilo Morejón",
        position: [{ positionName: "Catcher" }],
        img: "http://localhost:8000/src/logos/frank-camilo.jpg",
        age: 44,
        teams: ["Industriales"],
        current_Team: "Retirado",
        year_Experience: 17,
        position_Average: 253,
      },
    ],
    playersWinnerSerie: [
      {
        id: 1,
        name: "Alexander Malleta",
        position: [{ positionName: "Primera base" }],
        img: "http://localhost:8000/src/logos/malleta.jpg",
        age: 44,
        teams: ["Industriales", "Metropolitano"],
        current_Team: "Retirado",
        year_Experience: 20,
        position_Average: 301,
      },
      {
        id: 2,
        name: "Frank Camilo Morejón",
        position: [{ positionName: "Catcher" }],
        img: "http://localhost:8000/src/logos/frank-camilo.jpg",
        age: 44,
        teams: ["Industriales"],
        current_Team: "Retirado",
        year_Experience: 17,
        position_Average: 253,
      },
    ],
    playersLoserSerie: [
      {
        id: 1,
        name: "Alexander Malleta",
        position: [{ positionName: "Primera base" }],
        img: "http://localhost:8000/src/logos/malleta.jpg",
        age: 44,
        teams: ["Industriales", "Metropolitano"],
        current_Team: "Retirado",
        year_Experience: 20,
        position_Average: 301,
      },
      {
        id: 2,
        name: "Frank Camilo Morejón",
        position: [{ positionName: "Catcher" }],
        img: "http://localhost:8000/src/logos/frank-camilo.jpg",
        age: 44,
        teams: ["Industriales"],
        current_Team: "Retirado",
        year_Experience: 17,
        position_Average: 253,
      },
    ],
    winner: {
      id: 3,
      name: "Industriales",
      color: "Azul",
      iniciales: "IND",
      img: "http://localhost:8000/src/logos/industriales.png",
    },
    loser: {
      id: 4,
      name: "Cienfuegos",
      color: "Verde, Blanco",
      iniciales: "CFG",
      img: "http://localhost:8000/src/logos/cienfuegos.png",
    },
    winner_pitcher: { name: "Rivero" },
    runs_in_favor: 9,
    runs_against: 3,
    winner_players: [
      {
        id: 1,
        name: "Alexander Malleta",
        position: [{ positionName: "Primera base" }],
        img: "http://localhost:8000/src/logos/malleta.jpg",
        age: 44,
        teams: ["Industriales", "Metropolitano"],
        current_Team: "Retirado",
        year_Experience: 20,
        position_Average: 301,
      },
      {
        id: 2,
        name: "Frank Camilo Morejón",
        position: [{ positionName: "Catcher" }],
        img: "http://localhost:8000/src/logos/frank-camilo.jpg",
        age: 44,
        teams: ["Industriales"],
        current_Team: "Retirado",
        year_Experience: 17,
        position_Average: 253,
      },
    ],
    loser_players: [
      {
        id: 1,
        name: "Alexander Malleta",
        position: [{ positionName: "Primera base" }],
        img: "http://localhost:8000/src/logos/malleta.jpg",
        age: 44,
        teams: ["Industriales", "Metropolitano"],
        current_Team: "Retirado",
        year_Experience: 20,
        position_Average: 301,
      },
      {
        id: 2,
        name: "Frank Camilo Morejón",
        position: [{ positionName: "Catcher" }],
        img: "http://localhost:8000/src/logos/frank-camilo.jpg",
        age: 44,
        teams: ["Industriales"],
        current_Team: "Retirado",
        year_Experience: 17,
        position_Average: 253,
      },
    ],
    winner_changes: [
      {
        player: { name: "Juanito", position: [{ positionName: "Lanzador" }] },
        change: { name: "Pepito", position: [{ positionName: "Lanzador" }] },
      },
    ],
    loser_changes: [
      {
        player: { name: "Juanito", position: [{ positionName: "Lanzador" }] },
        change: { name: "Pepito", position: [{ positionName: "Lanzador" }] },
      },
      {
        player: { name: "Juanito", position: [{ positionName: "Lanzador" }] },
        change: { name: "Pepito", position: [{ positionName: "Lanzador" }] },
      },
    ],
  };

  handleOnClick = (p) => {
    this.setState({
      page: p,
      addPlayer: false,
      addChange: false,
      typeTeam: "",
    });
  };

  handleOnClickAddPlayer = (typeTeam) => {
    this.setState({ addPlayer: true, addChange: false, typeTeam: typeTeam });
  };
  handleOnClickAddChange = (typeTeam) => {
    this.setState({ addPlayer: false, addChange: true, typeTeam: typeTeam });
  };
  handleCloseAdd = () => {
    this.setState({ addChange: false, addPlayer: false });
  };

  render() {
    const { idGame, IdSerie } = this.props.location.state;
    return (
      <Container>
        <h1 className="mb-5 my-style-header">
          {this.state.winner.name}-{this.state.loser.name}
        </h1>
        <Row className="align-items-center">
          <Col className="text-center text-md-right">
            <Image
              style={{ width: "25%" }}
              fluid
              src={this.state.winner.img}
              alt=""
            />
          </Col>
          <Col className="text-center text-md-center bold score" md={2}>
            {this.state.runs_in_favor} - {this.state.runs_against}
          </Col>
          <Col className="text-center text-md-left">
            <Image
              style={{ width: "25%" }}
              fluid
              src={this.state.loser.img}
              alt=""
            />
          </Col>
        </Row>
        <Row className="justify-content-center mt-3">
          <p style={{ display: "inline" }}>
            <h className="bold">Lanzador ganador: </h>{" "}
            {this.state.winner_pitcher.name}.
          </p>
        </Row>
        <Row>
          <Col>
            <Card style={{ width: "100%" }}>
              <Card.Header>
                <Nav variant="tabs" defaultActiveKey={1}>
                  <Nav.Item onClick={() => this.handleOnClick(1)} key={1}>
                    <Nav.Link>Jugadores</Nav.Link>
                  </Nav.Item>
                  <Nav.Item onClick={() => this.handleOnClick(2)} key={2}>
                    <Nav.Link>Cambios</Nav.Link>
                  </Nav.Item>
                </Nav>
              </Card.Header>
              <Card.Body>
                {this.state.page === 1 && (
                  <Row style={{ fontSize: "10px" }}>
                    <Col>
                      <h6>Ganador</h6>
                      <Players
                        playerGeneral={false}
                        delete={true}
                        players={this.state.winner_players}
                      />
                      <Add
                        text="Agregar jugador"
                        onClick={() => this.handleOnClickAddPlayer("winner")}
                      />
                    </Col>
                    <Col>
                      <h6>Perdedor</h6>
                      <Players
                        playerGeneral={false}
                        delete={true}
                        players={this.state.loser_players}
                      />
                      <Add
                        text="Agregar jugador"
                        onClick={() => this.handleOnClickAddPlayer("loser")}
                      />
                    </Col>
                  </Row>
                )}
                {this.state.page === 2 && (
                  <Row>
                    <Col>
                      <h6>Ganador</h6>
                      <Table striped hover>
                        <thead>
                          <th>Jugador</th>
                          <th></th>
                          <th>Cambio</th>
                          <th></th>
                        </thead>
                        <tbody>
                          {this.state.winner_changes.map((change) => (
                            <tr>
                              <td>{change.player.name}</td>
                              <td>
                                <Image src={arrow} />
                              </td>
                              <td>{change.change.name}</td>
                              <DeleteEdit delete={true} />
                            </tr>
                          ))}
                        </tbody>
                      </Table>
                      <Add
                        text="Agregar cambio"
                        onClick={() => this.handleOnClickAddChange("winner")}
                      />
                    </Col>
                    <Col>
                      <h6>Perdedor</h6>
                      <Table striped hover>
                        <thead>
                          <th>Jugador</th>
                          <th></th>
                          <th>Cambio</th>
                          <th></th>
                        </thead>
                        <tbody>
                          {this.state.loser_changes.map((change) => (
                            <tr>
                              <td>{change.player.name}</td>
                              <td>
                                <Image src={arrow} />
                              </td>
                              <td>{change.change.name}</td>
                              <DeleteEdit delete={true} />
                            </tr>
                          ))}
                        </tbody>
                      </Table>
                      <Add
                        text="Agregar cambio"
                        onClick={() => this.handleOnClickAddChange("loser")}
                      />
                    </Col>
                  </Row>
                )}
              </Card.Body>
            </Card>
          </Col>
          {this.state.addPlayer && (
            <Col md={3}>
              <Navbar fixed="right">
                <Nav.Item>
                  <Form>
                    <Form.Group controlId="name">
                      <Form.Label>Jugador:</Form.Label>
                      {this.state.typeTeam === "winner" && (
                        <Form.Control as="select" custom>
                          <option>{""}</option>
                          {this.state.playersWinnerSerie.map((player) => (
                            <option>{player.name}</option>
                          ))}
                        </Form.Control>
                      )}
                      {this.state.typeTeam === "loser" && (
                        <Form.Control as="select" custom>
                          <option>{""}</option>
                          {this.state.playersLoserSerie.map((player) => (
                            <option>{player.name}</option>
                          ))}
                        </Form.Control>
                      )}
                    </Form.Group>
                    <Form.Group>
                      <Button
                        className="mr-2"
                        style={{ float: "left" }}
                        variant="primary"
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
                    </Form.Group>
                  </Form>
                </Nav.Item>
              </Navbar>
            </Col>
          )}
          {this.state.addChange && (
            <Col md={3}>
              <Navbar fixed="right">
                <Nav.Item>
                  <Form>
                    <Form.Group controlId="name">
                      <Form.Label>Jugador que salió:</Form.Label>
                      {this.state.typeTeam === "winner" && (
                        <Form.Control as="select" custom>
                          <option>{""}</option>
                          {this.state.playersWinnerGame.map((player) => (
                            <option>{player.name}</option>
                          ))}
                        </Form.Control>
                      )}
                      {this.state.typeTeam === "loser" && (
                        <Form.Control as="select" custom>
                          <option>{""}</option>
                          {this.state.playersLoserGame.map((player) => (
                            <option>{player.name}</option>
                          ))}
                        </Form.Control>
                      )}
                    </Form.Group>
                    <Form.Group controlId="name">
                      <Form.Label>Jugador que entró:</Form.Label>
                      {this.state.typeTeam === "winner" && (
                        <Form.Control as="select" custom>
                          <option>{""}</option>
                          {this.state.playersWinnerGame.map((player) => (
                            <option>{player.name}</option>
                          ))}
                        </Form.Control>
                      )}
                      {this.state.typeTeam === "loser" && (
                        <Form.Control as="select" custom>
                          <option>{""}</option>
                          {this.state.playersLoserGame.map((player) => (
                            <option>{player.name}</option>
                          ))}
                        </Form.Control>
                      )}
                    </Form.Group>
                    <Form.Group>
                      <Button
                        className="mr-2"
                        style={{ float: "left" }}
                        variant="primary"
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
                    </Form.Group>
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

export default Game;
