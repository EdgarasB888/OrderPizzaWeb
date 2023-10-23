import React, { useState, useEffect } from 'react'
import styled from "styled-components";
import Announcement from "../components/Announcement";
import Navbar from "../components/Navbar";
import { mobile } from "../responsive";
import PizzaOrdersService from '../services/pizzaOrders.service';
import { Card } from "@mui/material";
import { Routes } from '../routes';
import DeleteConfirmationPopup from '../components/delete/DeleteConfirmationPopup';

const Container = styled.div``;

const Wrapper = styled.div`
  padding: 20px;
  ${mobile({ padding: "10px" })}
`;

const Button = styled.button`
  width: 40%;
  border: none;
  padding: 15px 20px;
  background-color: brown;
  color: white;
  cursor: pointer;
  margin-top: 5px;
  margin-bottom: 5px;
`;

const PizzaOrdersList = () => {

  const [pizzaOrders, setPizzaOrders] = useState([]);

  const [deleteConfirmationPopupOpen, setDeleteConfirmationPopupOpen] = useState(false);
  const [deleteTarget, setDeleteTarget] = useState(null);

  const getPizzaOrders = () => {
    PizzaOrdersService.getMany().then((response) => {
      setPizzaOrders(response.data);
    }).catch((response) => {
      console.log(response);
    });
  };

  useEffect(() => {
    getPizzaOrders();
  }, []);

  return (
    <Container>
      <Navbar />
      <Announcement />

      <Wrapper style={{
        display: "flex", flexDirection: "column", alignItems: "center",
        justifyContent: "center", gap: "5px", width: "70%", margin: "auto"
      }}>
        <h2 style={{ textAlign: "center" }}>Your Orders</h2>
        <hr style={{ width: "100%" }} />

        <div style={{ display: "flex", flexWrap: "wrap", justifyContent: "center" }}>
          {pizzaOrders &&
            pizzaOrders.map((item) => (
              <Card key={item.id} style={{ width: "200px", marginRight: "20px", marginBottom: "20px", display: "flex", flexDirection: "column" }}>
                <div style={{ flex: 1 }}>
                  <span>
                    <h2 style={{ textAlign: "center" }}>Order {item.id}{" "}</h2>
                    <hr style={{ width: "100%" }} />
                  </span>
                  <span>
                    Pizza Size: <b>{item.size}</b>,{" "}
                    <br></br>
                    Cost: <b>{item.price}€</b>,{" "}
                  </span>
                </div>
                <div style={{ alignSelf: "flex-start" }}>
                  <span>
                    Toppings: <b>{item.amount}</b>{" "}
                  </span>
                  <ul>
                    {item.toppings.map((topping, index) => (
                      <b><li key={index}>{topping.name}</li></b>
                    ))}
                  </ul>
                </div>
                <hr style={{ width: "100%" }} />
                <center>
                  <Button onClick={() => {
                    setDeleteTarget(item.id);
                    setDeleteConfirmationPopupOpen(true);
                  }}
                    style={{
                      backgroundColor: "brown",
                      width: "100px",
                      height: "40px",
                    }}
                  >
                    DELETE
                  </Button>
                </center>
              </Card>
            ))}
        </div>
        <hr style={{ width: "100%" }} />
      </Wrapper>

      <DeleteConfirmationPopup
        open={deleteConfirmationPopupOpen}
        onClose={() => setDeleteConfirmationPopupOpen(false)}
        onDelete={async () => {
          await PizzaOrdersService.delete(deleteTarget);
          window.location.assign(Routes.OrdersList.path);
        }} />
    </Container>
  );
};

export default PizzaOrdersList;