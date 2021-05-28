import React, { Component } from "react";
import {
  Card,
  Nav,
  Table,
  Container,
  Row,
  Col,
  Image,
  Button,
  Navbar,
  Form,
} from "react-bootstrap";
import "./Serie.css";
import DeleteEdit from "../../components/DeleteEdit/DeleteEdit";
import Add from "../../components/Add/Add";
import {
  ProSidebar,
  Menu,
  MenuItem,
  SubMenu,
  SidebarContent,
  SidebarHeader,
} from "react-pro-sidebar";
import "react-pro-sidebar/dist/css/styles.css";

class Serie extends Component {
  state = {
    formTeam: false,
    itemEdit: {},
    standings: true,
    allstarteams: false,
  };

  handleOnClickStandings = () => {
    this.setState({ standings: true, allstarteams: false });
  };

  handleOnClickAllStarTeams = () => {
    this.setState({
      standings: false,
      allstarteams: true,
      formTeam: false,
      itemEdit: {},
    });
  };

  handleOnClickTeam = (idT, idS) => {
    this.props.history.push({
      pathname: "/serie_team",
      state: { idTeam: idT, idSerie: idS },
    });
  };

  handleFormTeam = (item) => {
    this.setState(
      this.state.formTeam
        ? item === undefined
          ? { formTeam: true, itemEdit: undefined }
          : this.state.itemEdit.team.id === item.team.id
          ? { formTeam: false, itemEdit: {} }
          : { formTeam: true, itemEdit: item }
        : { formTeam: true, itemEdit: item }
    );
  };

  handleOnAddTeam = () => {};
  handleOnAddPlayer = () => {};

  render() {
    const { id, name, standings, allstarteams } =
      this.props.location.state.serie;
    return (
      <Container>
        <h1 className="mb-5 my-style-header">{name}</h1>
        <Row>
          <Col>
            <Card>
              <Card.Header>
                <Nav variant="tabs" defaultActiveKey={1}>
                  <Nav.Item onClick={this.handleOnClickStandings} key={1}>
                    <Nav.Link>Posiciones</Nav.Link>
                  </Nav.Item>
                  <Nav.Item onClick={this.handleOnClickAllStarTeams} key={2}>
                    <Nav.Link>Todos Estrellas</Nav.Link>
                  </Nav.Item>
                </Nav>
              </Card.Header>
              <Card.Body>
                {this.state.standings && (
                  <Container>
                    <Table striped bordered hover>
                      <thead>
                        <tr>
                          <th></th>
                          <th></th>
                          <th>Equipos</th>
                          <th>Juegos ganados</th>
                          <th>Juegos perdidos</th>
                        </tr>
                      </thead>
                      <tbody>
                        {standings.map((item) => (
                          <tr key={item.place}>
                            <td
                              onClick={() =>
                                this.handleOnClickTeam(item.team.id, id)
                              }
                            >
                              {item.place}
                            </td>
                            <td
                              onClick={() =>
                                this.handleOnClickTeam(item.team.id, id)
                              }
                              style={{ width: "7%" }}
                            >
                              <Image fluid src={item.team.img} alt="" />
                            </td>
                            <td
                              onClick={() =>
                                this.handleOnClickTeam(item.team.id, id)
                              }
                            >
                              {item.team.name}
                            </td>
                            <td
                              onClick={() =>
                                this.handleOnClickTeam(item.team.id, id)
                              }
                            >
                              {item.won_games}
                            </td>
                            <td
                              onClick={() =>
                                this.handleOnClickTeam(item.team.id, id)
                              }
                            >
                              {item.lost_games}
                            </td>
                            <DeleteEdit
                              delete={true}
                              edit={true}
                              onEdit={() => this.handleFormTeam(item)}
                              size="lg"
                              top="3"
                              space="2"
                            />
                          </tr>
                        ))}
                      </tbody>
                    </Table>
                    <Add text="Agregar Equipo" onClick={this.handleFormTeam} />
                  </Container>
                )}
                {this.state.allstarteams && (
                  <Container className="list-unstyled">
                    {allstarteams.map((player) => (
                      <Card key={player.id} className="mb-2" border="light">
                        <Card.Header style={{ padding: "0.5%" }}>
                          <Row className="row">
                            <Col md={1}>
                              <Image
                                fluid
                                roundedCircle
                                src={player.img}
                                alt=""
                                className="custom-circle-image"
                              />
                            </Col>
                            <Col>
                              <h5>{player.name}</h5>
                            </Col>
                            <Col>
                              <p style={{ display: "inline" }}>
                                <h className="bold">Posiciones: </h>
                                {player.position}
                              </p>
                            </Col>
                            <Col md={2}>
                              <DeleteEdit
                                delete={true}
                                size="lg"
                                top="3"
                                space="2"
                                // style={{ paddingLeft: "20px" }}
                              />
                            </Col>
                          </Row>
                        </Card.Header>
                      </Card>
                    ))}
                    <Add
                      text="Agregar Jugador"
                      onClick={this.handleOnAddPlayer}
                    />
                  </Container>
                )}
              </Card.Body>
            </Card>
          </Col>
          {this.state.formTeam && (
            <Col md={3}>
              <Navbar fixed="right">
                <Nav.Item>
                  <Form>
                    <Form.Label>
                      <h3>
                        {this.state.itemEdit !== undefined
                          ? this.state.itemEdit.team.name
                          : ""}
                      </h3>
                    </Form.Label>
                    <Form.Group controlId="won_games">
                      <Form.Label>Juegos ganados:</Form.Label>
                      <Form.Control
                        value={
                          this.state.itemEdit !== undefined
                            ? this.state.itemEdit.won_games
                            : ""
                        }
                        type="numeric"
                        name="won_games"
                      />
                    </Form.Group>
                    <Form.Group controlId="lost_games">
                      <Form.Label>Juegos perdidos:</Form.Label>
                      <Form.Control
                        value={
                          this.state.itemEdit !== undefined
                            ? this.state.itemEdit.lost_games
                            : ""
                        }
                        type="numeric"
                        name="lost_games"
                      />
                    </Form.Group>
                    <Form.Group controlId="position">
                      <Form.Label>Posición:</Form.Label>
                      <Form.Control
                        value={
                          this.state.itemEdit !== undefined
                            ? this.state.itemEdit.place
                            : ""
                        }
                        type="numeric"
                        name="position"
                      />
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

export default Serie;
