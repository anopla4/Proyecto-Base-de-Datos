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
  Toast,
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
    nothingInStanding: false,
    idSerie: "",
    initDate: "",
    endDate: "",
    standingsData: [],
    allstarteamsData: [],
    teams: [],
    positions: [],
    players: [],
    editTeam: false,
    addTeam: false,
    addPlayer: false,
    itemEdit: {},
    standings: true,
    allstarteams: false,
  };

  handleOnClickStandings = () => {
    this.setState({ standings: true, allstarteams: false, addPlayer: false });
  };

  handleOnClickAllStarTeams = () => {
    this.setState({
      standings: false,
      allstarteams: true,
      editTeam: false,
      addTeam: false,
      itemEdit: {},
    });
  };

  handleOnClickTeam = (team, serie) => {
    this.props.history.push({
      pathname: "/serie_team",
      state: { team: team, serie: serie },
    });
  };

  handleEditTeam = (item) => {
    this.setState({
      addTeam: false,
      editTeam: true,
      itemEdit: item,
    });
  };

  handleOnAddTeam = () => {
    this.setState({
      nothingInStanding: false,
      addTeam: true,
      editTeam: false,
      itemEdit: {},
    });
  };

  handleOnAddPlayer = () => {
    this.setState({ addPlayer: true });
  };
  handleCloseFormTeam = () => {
    this.setState({ editTeam: false, addTeam: false, itemEdit: {} });
  };
  handleCloseAddPlayer = () => {
    this.setState({ addPlayer: false });
  };

  formatDate = (date) => {
    let d = new Date(date);
    return `${d.getFullYear()}-${d.getMonth() + 1}-${d.getDate()}`;
  };

  onFormSubmit = (e) => {
    let formElements = e.target.elements;
    if (this.state.standings) {
      const team = formElements.team;
      const teamId = team ? team.children[team.selectedIndex].id : "";
      const wonGames = formElements.won_games.value;
      const lostGames = formElements.lost_games.value;
      const finalPosition = formElements.position.value;
      let item = {
        wonGames: wonGames,
        lostGames: lostGames,
        finalPosition: finalPosition,
      };
      let postUrl =
        "https://localhost:44334/api/TeamSerie" +
        (this.state.editTeam
          ? `/${this.state.itemEdit.team.id}/${
              this.state.idSerie
            }/${this.formatDate(this.state.initDate)}/${this.formatDate(
              this.state.endDate
            )}`
          : "");

      let teamSerie = this.state.editTeam
        ? item
        : {
            teamId: teamId,
            serieId: this.state.idSerie,
            serieInitDate: this.formatDate(this.state.initDate),
            serieEndDate: this.formatDate(this.state.endDate),
            ...item,
          };
      fetch(postUrl, {
        mode: "cors",
        headers: { "Content-Type": "application/json" },
        method: this.state.editTeam ? "PATCH" : "POST",
        body: JSON.stringify(teamSerie),
      })
        .then((response) => {
          if (!response.ok) {
            throw Error(response.statusText);
          }
          return response.json();
        })
        .catch(function (error) {
          console.log(
            "Hubo un problema con la petición Fetch:" + error.message
          );
        });
      this.setState({
        editTeam: false,
        addTeam: false,
      });
    } else {
      const player = formElements.player;
      const playerId = player ? player.children[player.selectedIndex].id : "";
      const position = formElements.position;
      const positionId = position
        ? position.children[position.selectedIndex].id
        : "";
      let item = {
        playerId: playerId,
        positionId: positionId,
        serieId: this.state.idSerie,
        serieInitDate: this.state.serieInitDate,
        serieEndDate: this.state.serieEndDate,
      };
      fetch("https://localhost:44334/api/StarPositionPlayerSerie", {
        mode: "cors",
        headers: { "Content-Type": "application/json" },
        method: "POST",
        body: JSON.stringify(item),
      })
        .then((response) => {
          if (!response.ok) {
            throw Error(response.statusText);
          }
          return response.json();
        })
        .catch(function (error) {
          console.log(
            "Hubo un problema con la petición Fetch:" + error.message
          );
        });
      this.setState({
        addPlayer: false,
      });
    }
  };

  componentWillMount() {
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
    fetch("https://localhost:44334/api/Position", { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ positions: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    fetch(
      `https://localhost:44334/api/TeamSeriePlayer/${this.state.idSerie}/${this.state.initDate}/${this.state.endDate}`,
      { mode: "cors" }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ players: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });

    this.setState({
      idSerie: this.props.location.state.serie.id,
      initDate: this.props.location.state.serie.initDate,
      endDate: this.props.location.state.serie.endDate,
    });
  }

  componentDidMount() {
    fetch(
      `https://localhost:44334/api/TeamSerie/Standing/${
        this.state.idSerie
      }/${this.formatDate(this.state.initDate)}/${this.formatDate(
        this.state.endDate
      )}`,
      { mode: "cors" }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ standingsData: response });
      })
      .catch((error) => {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
        this.setState({ nothingInStanding: true });
      });
    fetch(
      `https://localhost:44334/api/StarPositionPlayerSerie/${
        this.state.idSerie
      }/${this.formatDate(this.state.initDate)}/${this.formatDate(
        this.state.endDate
      )}`,
      { mode: "cors" }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ allstarteamsData: response });
      })
      .catch((error) => {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
        this.setState({ nothingInStanding: true });
      });
  }

  handleDeleteTeam = (idT, index) => {
    fetch(
      `https://localhost:44334/api/TeamSerie/${idT}/${
        this.state.idSerie
      }/${this.formatDate(this.state.initDate)}/${this.formatDate(
        this.state.endDate
      )}`,
      {
        mode: "cors",
        method: "DELETE",
      }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });

    let n_standings = [...this.state.standingsData];
    n_standings.splice(index, 1);

    this.setState({ standingsData: n_standings });
    if (this.state.standingsData.length === 0) {
      this.setState({ nothingInStanding: true });
    }
  };

  handleDeletePlayer = (idPos, index) => {
    fetch(
      `https://localhost:44334/api/StarPositionPlayerSerie/${
        this.state.idSerie
      }/${this.formatDate(this.state.initDate)}/${this.formatDate(
        this.state.endDate
      )}/${idPos}`,
      {
        mode: "cors",
        method: "DELETE",
      }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });

    let n_allstarteams = [...this.state.allstarteamsData];
    n_allstarteams.splice(index, 1);

    this.setState({ allstarteamsData: n_allstarteams });
  };

  render() {
    const { id, name } = this.props.location.state.serie;
    return (
      <Container>
        <h1 className="mb-5 my-style-header">{name}</h1>
        {this.state.nothingInStanding && (
          <Row className="mb-3">
            <Col md={3} style={{ alignItems: "right" }}>
              <Toast>
                <Toast.Header>
                  <strong className="mr-auto">Atención!</strong>
                </Toast.Header>
                <Toast.Body>
                  No se ha agregado la tabla de posiciones de la serie.
                </Toast.Body>
              </Toast>
            </Col>
          </Row>
        )}
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
                        {this.state.standingsData.map((item, index) => (
                          <tr key={item.team.id}>
                            <td
                              onClick={() =>
                                this.handleOnClickTeam(item.team, item.serie)
                              }
                            >
                              {item.finalPosition}
                            </td>
                            <td
                              onClick={() =>
                                this.handleOnClickTeam(item.team, item.serie)
                              }
                              style={{ width: "7%" }}
                            >
                              <Image
                                fluid
                                src={`https://localhost:44334:${item.team.imgPath}`}
                                alt=""
                              />
                            </td>
                            <td
                              onClick={() =>
                                this.handleOnClickTeam(item.team, item.serie)
                              }
                            >
                              {item.team.name}
                            </td>
                            <td
                              onClick={() =>
                                this.handleOnClickTeam(item.team, item.serie)
                              }
                            >
                              {item.wonGames}
                            </td>
                            <td
                              onClick={() =>
                                this.handleOnClickTeam(item.team, item.serie)
                              }
                            >
                              {item.lostGames}
                            </td>
                            <DeleteEdit
                              delete={true}
                              edit={true}
                              onEdit={() => this.handleEditTeam(item)}
                              onDelete={() =>
                                this.handleDeleteTeam(item.team.id, index)
                              }
                              size="lg"
                              top="3"
                              space="2"
                            />
                          </tr>
                        ))}
                      </tbody>
                    </Table>
                    <Add text="Agregar Equipo" onClick={this.handleOnAddTeam} />
                  </Container>
                )}
                {this.state.allstarteams && (
                  <Container className="list-unstyled">
                    {this.state.allstarteamsData.map((player) => (
                      <Card key={player.id} className="mb-2" border="light">
                        <Card.Header style={{ padding: "0.5%" }}>
                          <Row className="row">
                            <Col md={1}>
                              <Image
                                fluid
                                roundedCircle
                                src={`https://localhost:44334/${player.imgPath}`}
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
          {(this.state.editTeam || this.state.addTeam) && (
            <Col md={3}>
              <Navbar fixed="right">
                <Nav.Item>
                  <Form
                    onSubmit={this.onFormSubmit}
                    key={
                      this.state.itemEdit.team ? this.state.itemEdit.team.id : 0
                    }
                  >
                    {this.state.addTeam && (
                      <Form.Group controlId="team">
                        <Form.Label>Equipo:</Form.Label>
                        <Form.Control as="select" custom>
                          <option>
                            {this.state.editTeam
                              ? this.state.editTeam.name
                              : ""}
                          </option>
                          {this.state.teams.map((team) => (
                            <option id={team.id}>{team.name}</option>
                          ))}
                        </Form.Control>
                      </Form.Group>
                    )}
                    {this.state.editTeam && (
                      <Form.Label>
                        <h3>{this.state.itemEdit.team.name}</h3>
                      </Form.Label>
                    )}
                    <Form.Group controlId="won_games">
                      <Form.Label>Juegos ganados:</Form.Label>
                      <Form.Control
                        defaultValue={
                          this.state.editTeam
                            ? this.state.itemEdit.wonGames
                            : ""
                        }
                        type="numeric"
                        name="won_games"
                      />
                    </Form.Group>
                    <Form.Group controlId="lost_games">
                      <Form.Label>Juegos perdidos:</Form.Label>
                      <Form.Control
                        defaultValue={
                          this.state.editTeam
                            ? this.state.itemEdit.lostGames
                            : ""
                        }
                        type="numeric"
                        name="lost_games"
                      />
                    </Form.Group>
                    <Form.Group controlId="position">
                      <Form.Label>Posición:</Form.Label>
                      <Form.Control
                        defaultValue={
                          this.state.editTeam
                            ? this.state.itemEdit.finalPosition
                            : ""
                        }
                        type="numeric"
                        name="position"
                      />
                    </Form.Group>
                    <Form.Group>
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
                        onClick={this.handleCloseFormTeam}
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

          {this.state.addPlayer && (
            <Col md={3}>
              <Navbar fixed="right">
                <Nav.Item>
                  <Form onSubmit={this.onFormSubmit}>
                    <Form.Group controlId="name">
                      <Form.Label>Jugador:</Form.Label>
                      <Form.Control as="select" custom>
                        <option>{""}</option>
                        {this.state.players.map((player) => (
                          <option id={player.id}>
                            {player.name} ({player.team})
                          </option>
                        ))}
                      </Form.Control>
                    </Form.Group>
                    <Form.Group controlId="name">
                      <Form.Label>Posición:</Form.Label>
                      <Form.Control as="select" custom>
                        <option>{""}</option>
                        {this.state.positions.map((pos) => (
                          <option id={pos.id}>{pos}</option>
                        ))}
                      </Form.Control>
                    </Form.Group>
                    <Form.Group>
                      <Button
                        className="mr-2"
                        style={{ float: "left" }}
                        type="submit"
                        variant="primary"
                      >
                        Aceptar
                      </Button>
                      <Button
                        style={{ float: "right" }}
                        onClick={this.handleCloseAddPlayer}
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

export default Serie;
