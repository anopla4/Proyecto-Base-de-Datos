import React, { Component } from "react";
import { Container, Button } from "react-bootstrap";
import { TrashFill, PencilSquare } from "react-bootstrap-icons";

class DeleteEdit extends Component {
  render() {
    return (
      <Container style={{ margin: "0px", padding: "2px" }}>
        {this.props.edit && (
          <Button
            style={{ padding: "0px", float: "right" }}
            className={
              "ml-" +
              this.props.space +
              " mr-2 mt-" +
              this.props.top +
              " btn-outline-secondary"
            }
            size={this.props.size}
            variant="light"
          >
            <PencilSquare style={{ width: "100%" }} />
          </Button>
        )}
        {this.props.delete && (
          <Button
            className={"mt-" + this.props.top + " mr-1"}
            style={{ padding: "0px", float: "right" }}
            size={this.props.size}
            variant="danger"
          >
            <TrashFill style={{ width: "100%" }} />
          </Button>
        )}
      </Container>
    );
  }
}

export default DeleteEdit;
