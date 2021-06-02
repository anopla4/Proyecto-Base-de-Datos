import React, { Component } from "react";
import { Card, Container, Col, Row, Image } from "react-bootstrap";
import "../../containers/App/App.css";
import "./Directors.css";
import DeleteEdit from "../../components/DeleteEdit/DeleteEdit";
import isLoggedIn from "../utils";

class Directors extends Component {
  render() {
    return (
      <Container className="list-unstyled">
        {this.props.directors.map((dir, index) => (
          <Card key={dir.id} className="mb-2">
            <Card.Header style={{ padding: "0.5%" }}>
              <Row className="row align-items-center">
                <Col md={1}>
                  <Image
                    fluid
                    roundedCircle
                    src={`https://localhost:44334/${dir.imgPath}`}
                    style={{ height: "85px" }}
                    alt=""
                    className="custom-circle-image"
                  />
                </Col>
                <Col>
                  <h5>{dir.name}</h5>
                  {dir.directed_teams && (
                    <Container style={{ display: "inline" }}>
                      <p className="bold">Equipos dirigidos: </p>
                      {dir.directed_teams.join(", ")}.
                    </Container>
                  )}
                </Col>
                <Col>
                  <DeleteEdit
                    delete={this.props.delete}
                    edit={this.props.edit}
                    onDelete={() => this.props.onDelete(dir.id, index)}
                    onEdit={() => this.props.onEdit(dir)}
                  />
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
