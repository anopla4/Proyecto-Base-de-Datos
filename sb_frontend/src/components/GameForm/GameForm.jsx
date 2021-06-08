import React, { Component } from "react";
import { Form, Button, Row, Col, Container } from "react-bootstrap";
import "./GameForm.css";

class GameForm extends Component {
  state = {
    game: {},
    edit: false,
    changed: false,
    pitchers: [],
    teams: [],
    series: [],
  };
  //   onChange = (e) => {
  //     e.preventDefault();
  //     this.setState((prevState) => ({
  //       changed: true,
  //       selectedPositions: [...prevState.selectedPositions, e.target.value],
  //     }));
  //   };

  formatDate = (date) => {
    let d = new Date(date);
    return `${d.getFullYear()}-${d.getMonth() + 1}-${d.getDate()}`;
  };

  componentWillMount() {
    if (this.props.location.state.game) {
      this.setState({ edit: true, game: this.props.location.state.game });
    }
    fetch(`https://localhost:44334/api/Team`, {
      mode: "cors",
    })
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
    fetch("https://localhost:44334/api/Serie", { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ series: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
    fetch("https://localhost:44334/api/Player/Pitchers", { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ pitchers: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
  }

  onFormSubmit = (e) => {
    let formElements = e.target.elements;
    const serie = formElements.serie;
    const serieId = serie.children[serie.selectedIndex].id;
    console.log(
      this.formatDate(
        new Date(this.state.series.find((c) => c.id === serieId).endDate)
      )
    );
    const serieInitDate = this.state.edit
      ? this.props.location.state.serie.initDate
      : this.formatDate(
          new Date(this.state.series.find((c) => c.id === serieId).initDate)
        );
    const serieEndDate = this.state.edit
      ? this.props.location.state.serie.endDate
      : this.formatDate(
          new Date(this.state.series.find((c) => c.id === serieId).endDate)
        );
    const gameDate = this.state.edit
      ? this.props.location.state.game.gameDate
      : formElements.gameDate.value;
    const gameTime = this.state.edit
      ? this.props.location.state.game.gameTime
      : formElements.gameTime.value;
    const winner = formElements.winner;
    const winerTeamId = winner.children[winner.selectedIndex].id;
    const loser = formElements.loser;
    const loserTeamId = loser.children[loser.selectedIndex].id;
    const winner_pitcher = formElements.winner_pitcher;
    const pitcherWinerId =
      winner_pitcher.children[winner_pitcher.selectedIndex].id;
    const loser_pitcher = formElements.loser_pitcher;
    const pitcherLoserId =
      loser_pitcher.children[loser_pitcher.selectedIndex].id;
    const AgaintsCarrers = formElements.runs_against.value;
    const inFavorCarrers = formElements.runs_in_favor.value;

    let game = {
      serieInitDate,
      serieEndDate,
      serieId,
      winerTeamId,
      loserTeamId,
      gameDate,
      gameTime,
      pitcherWinerId,
      pitcherLoserId,
      AgaintsCarrers,
      inFavorCarrers,
    };
    fetch("https://localhost:44334/api/Game", {
      mode: "cors",
      headers: {
        "Content-Type": "application/json",
        Authorization:
          "Bearer " + JSON.parse(localStorage.getItem("loggedUser")).jwt_token,
      },
      method: this.state.edit ? "PATCH" : "POST",
      body: JSON.stringify(game),
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
    this.props.history.push({ pathname: "/games", state: { edited: true } });
  };

  render() {
    const {
      id,
      winerTeam,
      loserTeam,
      gameDate,
      gameTime,
      serie,
      pitcherWiner,
      pitcherLoser,
      InFavorCarrers,
      AgaintsCarrers,
    } = {
      ...this.props.location.state.game,
    };
    return (
      <Container alignSelf="center" className="mt-4">
        <h1 className="mb-5 my-style-header">Juego</h1>

        <Col className="center">
          <Form
            onSubmit={this.onFormSubmit}
            style={{ width: "70%", alignItems: "center" }}
          >
            <Row>
              <Col>
                <Form.Group style={{ width: "100%" }} controlId="serie">
                  <Form.Label>Serie:</Form.Label>
                  <Form.Control as="select" custom>
                    {serie && (
                      <option id={serie.id}>
                        {serie.name} (
                        {
                          new Date(serie.initDate)
                            .toLocaleString()
                            .split(",")[0]
                        }{" "}
                        -{" "}
                        {new Date(serie.endDate).toLocaleString().split(",")[0]}
                        ) : ""
                      </option>
                    )}
                    {this.state.series.map((serie) => (
                      <option id={serie.id}>
                        {serie.name} (
                        {
                          new Date(serie.initDate)
                            .toLocaleString()
                            .split(",")[0]
                        }{" "}
                        -{" "}
                        {new Date(serie.endDate).toLocaleString().split(",")[0]}
                        )
                      </option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="gameDate">
                  <Form.Label>Fecha de incio:</Form.Label>
                  <Form.Control
                    defaultValue={
                      gameDate
                        ? new Date(gameDate).toISOString().substr(0, 10)
                        : ""
                    }
                    disabled={this.state.edit ? true : false}
                    type="date"
                  />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="gameTime">
                  <Form.Label>Hora:</Form.Label>
                  <Form.Control
                    defaultValue={gameTime ? gameTime : ""}
                    type="text"
                    name="gameTime"
                  />
                  <Form.Text id="helpTime" muted>
                    El formato de la hora debe ser hh:mm.
                  </Form.Text>
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                <Form.Group
                  style={{ width: "100%" }}
                  controlId="winner_pitcher"
                >
                  <Form.Label>Lanzador ganador:</Form.Label>
                  <Form.Control as="select" custom>
                    {pitcherWiner && (
                      <option id={pitcherWiner.id}>{pitcherWiner.name}</option>
                    )}
                    {this.state.pitchers.map((pitcher) => (
                      <option id={pitcher.id}>{pitcher.name}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
              <Col>
                <Form.Group style={{ width: "100%" }} controlId="loser_pitcher">
                  <Form.Label>Lanzador perdedor:</Form.Label>
                  <Form.Control as="select" custom>
                    {pitcherLoser && (
                      <option id={pitcherLoser.id}>{pitcherLoser.name}</option>
                    )}
                    {this.state.pitchers.map((pitcher) => (
                      <option id={pitcher.id}>{pitcher.name}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                <Form.Group controlId="runs_in_favor">
                  <Form.Label>Carreras a favor:</Form.Label>
                  <Form.Control
                    defaultValue={InFavorCarrers ? InFavorCarrers : ""}
                    type="numeric"
                    name="runs_in_favor"
                  />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group controlId="runs_against">
                  <Form.Label>Carreras en contra:</Form.Label>
                  <Form.Control
                    defaultValue={AgaintsCarrers ? AgaintsCarrers : ""}
                    type="numeric"
                    name="runs_against"
                  />
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col>
                <Form.Group style={{ width: "100%" }} controlId="winner">
                  <Form.Label>Ganador:</Form.Label>
                  <Form.Control as="select" custom>
                    {winerTeam && (
                      <option id={winerTeam.id}>{winerTeam.anme}</option>
                    )}
                    {this.state.teams.map((team) => (
                      <option id={team.id}>{team.name}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
              <Col>
                <Form.Group style={{ width: "100%" }} controlId="loser">
                  <Form.Label>Perdedor:</Form.Label>
                  <Form.Control as="select" custom>
                    {loserTeam && (
                      <option id={loserTeam.id}>{loserTeam.name}</option>
                    )}
                    {this.state.teams.map((team) => (
                      <option id={team.id}>{team.name}</option>
                    ))}
                  </Form.Control>
                </Form.Group>
              </Col>
            </Row>
            <Button
              style={{ float: "right" }}
              className="mt-3 ml-3"
              variant="secondary"
              type="reset"
            >
              Reiniciar
            </Button>
            <Button
              style={{ float: "right" }}
              className="mt-3 ml-3"
              variant="primary"
              type="submit"
            >
              Aceptar
            </Button>
          </Form>
        </Col>
      </Container>
    );
  }
}

export default GameForm;
