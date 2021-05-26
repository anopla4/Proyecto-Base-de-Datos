import React, { Component } from "react";
import { Card, Container, Col, Row, Image } from "react-bootstrap";
import "../../containers/App/App.css";

class Directors extends Component {
  state = {
    directors: [
      {
        id: 1,
        name: "Víctor Mesa",
        img: "http://localhost:8000/src/logos/victor-mesa.jpg",
        directed_teams: ["Villa Clara", "Matanzas", "Cuba"],
      },
      {
        id: 2,
        name: "Alfonso Urquiola",
        img: "http://localhost:8000/src/logos/Alfonso_Urquiola_Crespo.jpg",
        directed_teams: ["Pinar del Río", "Cuba"],
      },
    ],
  };
  render() {
    return (
      <Container className="list-unstyled">
        <h1 className="mb-5 my-style-header">Directores de béisbol</h1>
        {this.state.directors.map((dir) => (
          <Card key={dir.id} className="mb-2" border="info">
            <Card.Header style={{ padding: "0.5%" }}>
              <Row className="row">
                <Col md={1}>
                  <Image
                    fluid
                    roundedCircle
                    src={dir.img}
                    alt=""
                    className="custom-circle-image"
                  />
                </Col>
                <Col>
                  <h5>{dir.name}</h5>
                  <p style={{ display: "inline" }}>
                    <h className="bold">Equipos dirigidos: </h>
                    {dir.directed_teams.join(", ")}.
                  </p>
                </Col>
              </Row>
            </Card.Header>
          </Card>
        ))}
      </Container>
    );
  }
}

export default Directors;
