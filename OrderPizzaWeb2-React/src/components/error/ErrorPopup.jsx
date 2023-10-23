import styled from "styled-components";
import { Card } from "@mui/material";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Modal from "@mui/material/Modal";

const Button = styled.button`
  border: none;
  padding: 15px 20px;
  background-color: brown;
  color: white;
  cursor: pointer;
  width: 25%;
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

const ErrorPopup = (props) => {
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
          width: 400,
          backgroundColor: "white",
          boxShadow: 24,
          p: 4,
        }}
      >
        <Card style={{ padding: 20, textAlign: 'center' }}>
          <Typography id="modal-modal-title" variant="h6" component="h4">
            <h4>{props.text}</h4>
          </Typography>

          <Hr></Hr>

          <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', marginTop: 20 }}>
            <Button
              onClick={async () => {
                props.onClose();
              }}
            >
              DISMISS
            </Button>
          </div>
        </Card>
      </Box>
    </Modal>
  );
};

export default ErrorPopup;