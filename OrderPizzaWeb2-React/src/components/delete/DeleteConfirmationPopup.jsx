import styled from "styled-components";
import { Card } from "@mui/material";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Modal from "@mui/material/Modal";

const Button = styled.button`
  border: none;
  padding: 15px 20px;
  background-color: teal;
  color: white;
  cursor: pointer;
`;

const DeleteConfirmationPopup = (props) => {
  return (
    <Modal
      open={props.open}
      onClose={props.onClose}
      aria-labelledby="modal-modal-title"
      aria-describedby="modal-modal-description"
    >
      <Box
        style={{
          position: "absolute",
          top: "50%",
          left: "50%",
          transform: "translate(-50%, -50%)",
          width: 450,
          backgroundColor: "white",
          boxShadow: 24,
          p: 4,
        }}
      >
        <Card style={{ padding: 20, textAlign: 'center' }}>
          <Typography>
            <h4>Are you sure you want to delete this order?</h4>
          </Typography>
          <hr style={{ marginTop: 10 }}></hr>
          <Typography id="modal-modal-description" sx={{ mt: 2 }}>
            {props.text}
          </Typography>
          <Button style={{ backgroundColor: "green" }} onClick={async () => {
            await props.onDelete();
            props.onClose();
          }}>Yes, I am sure</Button>
          <Button style={{ backgroundColor: "darkred", marginLeft: 135 }} onClick={async () => {
            props.onClose();
          }}>No, I am not</Button>
        </Card>
      </Box>
    </Modal>
  );
};

export default DeleteConfirmationPopup;