import React, { Component } from "react";
import { Card, Nav, Table, Container, Row, Col, Image } from "react-bootstrap";
import "./Serie.css";

class Serie extends Component {
  state = {
    standings: true,
    allstarteams: false,
  };

  handleOnClickStandings = () => {
    this.setState({ standings: true, allstarteams: false });
  };

  handleOnClickAllStarTeams = () => {
    this.setState({ standings: false, allstarteams: true });
  };

  handleOnClickTeam = (idT, idS) => {
    this.props.history.push({
      pathname: "/serie_team",
      state: { idTeam: idT, idSerie: idS },
    });
  };

  render() {
    const { id, name, standings, allstarteams } =
      this.props.location.state.serie;
    return (
      <Container>
        <h1 className="mb-5 my-style-header">{name}</h1>
        <Card>
          <Card.Header>
            <Nav variant="tabs" defaultActiveKey={1}>
              <Nav.Item onClick={this.handleOnClickStandings} key={1}>
                <Nav.Link>Poisiciones</Nav.Link>
              </Nav.Item>
              <Nav.Item onClick={this.handleOnClickAllStarTeams} key={2}>
                <Nav.Link>Todos Estrellas</Nav.Link>
              </Nav.Item>
            </Nav>
          </Card.Header>
          <Card.Body>
            {this.state.standings && (
              <Table striped bordered hover>
                <thead>
                  <tr>
                    <th></th>
                    <th>Equipos</th>
                    <th>Juegos ganados</th>
                    <th>Juegos perdidos</th>
                  </tr>
                </thead>
                <tbody>
                  {standings.map((item) => (
                    <tr
                      key={item.team.id}
                      onClick={() => this.handleOnClickTeam(item.team.id, id)}
                    >
                      <td style={{ width: "7%" }}>
                        <Image fluid src={item.team.img} alt="" />
                      </td>
                      <td>{item.team.name}</td>
                      <td>{item.won_games}</td>
                      <td>{item.lost_games}</td>
                    </tr>
                  ))}
                </tbody>
              </Table>
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
                      </Row>
                    </Card.Header>
                  </Card>
                ))}
              </Container>
            )}
          </Card.Body>
        </Card>
      </Container>
    );
  }
}

export default Serie;
