import React, { Component } from "react";
import { Card, Container, Col, Row, Image } from "react-bootstrap";
import "../../containers/App/App.css";
import "./Directors.css";

class Directors extends Component {
  render() {
    return (
      <Container className="list-unstyled">
        {this.props.directors.map((dir) => (
          <Card key={dir.id} className="mb-2">
            <Card.Header style={{ padding: "0.5%" }}>
              <Row className="row align-items-center">
                <Col md={1}>
                  <Image
                    fluid
                    roundedCircle
                    src={dir.img}
                    style={{ height: "85px" }}
                    alt=""
                    className="custom-circle-image"
                  />
                </Col>
                <Col>
                  <h5>{dir.name}</h5>
                  {dir.directed_teams && (
                    <p style={{ display: "inline" }}>
                      <h className="bold">Equipos dirigidos: </h>
                      {dir.directed_teams.join(", ")}.
                    </p>
                  )}
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
