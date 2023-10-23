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

const Hr = styled.hr`
  background-color: #696969;
  text-align: center;
  border: none;
  height: 1px;
  background: #696969;
  width: 100%;
  margin: auto;
`;

const ConfirmationPopup = (props) => {
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
          <Typography id="modal-modal-title" variant="h6" component="h4">
            <h4>Are you sure you want to order this pizza?</h4>
          </Typography>
          <Hr></Hr>
          <Typography id="modal-modal-description" sx={{ mt: 2 }}>
            {props.text}
          </Typography>
          <Button style={{ backgroundColor: "green" }} onClick={async () => {
            await props.onConfirm();
            props.onClose();
          }}>Yes, I confirm</Button>
          <Button style={{ backgroundColor: "brown", marginLeft: 135 }} onClick={async () => {
            props.onClose();
          }}>No, I do not</Button>
        </Card>
      </Box>
    </Modal>
  );
};

export default ConfirmationPopup;
