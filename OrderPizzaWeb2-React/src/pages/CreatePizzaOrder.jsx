import React, { useState, useEffect } from 'react'
import styled from "styled-components";
import Announcement from "../components/Announcement";
import Navbar from "../components/Navbar";
import { mobile } from "../responsive";
import ToppingsService from '../services/toppings.service';
import PizzaOrdersService from '../services/pizzaOrders.service';
import { Select, MenuItem } from "@mui/material";
import { Card } from "@mui/material";
import ErrorPopup from '../components/error/ErrorPopup';
import ConfirmationPopup from '../components/confirm/ConfirmationPopup';
import { Routes } from '../routes';

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
  margin-bottom: 10px;
`;

const Button2 = styled.button`
  width: 40%;
  border: none;
  padding: 10px 10px;
  background-color: brown;
  color: white;
  cursor: pointer;
  margin-bottom: 10px;
`;

const CreatePizzaOrder = () => {

  const [sizes, setSizes] = useState(["Small", "Medium", "Large"]);
  const [selectedSize, setSelectedSize] = useState(null);

  const [toppings, setToppings] = useState([]);
  const [selectedTopping, setSelectedTopping] = useState(null);

  const [selectedToppingsList, setSelectedToppingsList] = useState([]);

  const [totalPizzaCost, setTotalPizzaCost] = useState(0);

  const [errorPopupOpen, setErrorPopupOpen] = useState(false);
  const [errorPopupMessage, setErrorPopupMessage] = useState("");

  const [confirmationPopupOpen, setConfirmationPopupOpen] = useState(false);

  const handleSubmit = (e) => {
    if (selectedSize) {
      setConfirmationPopupOpen(true);
    } else {
      setErrorPopupMessage("Please select pizza size!");
      setErrorPopupOpen(true);
    }
  }

  const getToppings = () => {
    ToppingsService.getMany().then((response) => {
      setToppings(response.data);
    }).catch((response) => {
      console.log(response);
    });
  };

  useEffect(() => {
    getToppings();
  }, []);

  const calculateTotalCost = (size, toppings) => {
    PizzaOrdersService.calculateTotalOrderCost({ size, toppings })
      .then((response) => {
        setTotalPizzaCost(response.data);
      })
      .catch((error) => {
        console.error("Error calculating total pizza cost:", error);
      });
  };

  const addTopping = async () => {
    if (selectedTopping && selectedSize) {
      const selectedToppingObj = toppings.find(topping => topping.id === selectedTopping);

      if (selectedToppingObj) {
        if (!selectedToppingsList.some((item) => item.id === selectedToppingObj.id)) {
          const updatedToppingsList = [...selectedToppingsList, selectedToppingObj];
          setSelectedToppingsList(updatedToppingsList);

          calculateTotalCost(selectedSize, updatedToppingsList);
        } else {
          setErrorPopupMessage("This pizza topping is already selected!");
          setErrorPopupOpen(true);
        }
      }

      setSelectedTopping(null);
    } else {
      setErrorPopupMessage("Please select pizza size and topping!");
      setErrorPopupOpen(true);
    }
  }

  const addPizzaOrder = () => {
    const selectedToppingIds = selectedToppingsList.map((topping) => topping.id);
    const pizzaOrderToAdd = { size: selectedSize, price: totalPizzaCost, ToppingIds: selectedToppingIds };
    PizzaOrdersService.create(pizzaOrderToAdd);
    window.location.assign(Routes.OrdersList.path);
  }

  return (
    <Container>
      <Navbar />
      <Announcement />
      <Wrapper onSubmit={handleSubmit} style={{
        display: "flex", flexDirection: "column", alignItems: "center",
        justifyContent: "center", gap: "5px", width: "70%", margin: "auto"
      }}>
        <h2 style={{ textAlign: "center" }}>Create Your Pizza</h2>
        <hr style={{ width: "100%" }} />

        <div style={{ width: "100%", marginTop: "2em", display: "flex", flexDirection: "row", gap: "50px", alignContent: "stretch" }}>
          <div style={{ flexGrow: 1, display: "flex", flexDirection: "column", alignItems: "center" }}>
            <b>Select Size:</b>
            <Select
              style={{ width: 270 }}
              value={selectedSize}
              onChange={(x) => {
                setSelectedSize(x.target.value);
              }}
              label="Size"
            >
              {sizes &&
                sizes.map((x) => (
                  <MenuItem value={x}>
                    {x}
                  </MenuItem>
                ))}
            </Select>
          </div>
          <div style={{ flexGrow: 1, display: "flex", flexDirection: "column", alignItems: "center" }}>
            <b>Select Topping:</b>
            <Select
              style={{ width: 270 }}
              value={selectedTopping}
              onChange={(x) => {
                setSelectedTopping(x.target.value);
              }}
              label="Topping"
            >
              {toppings &&
                toppings.map((x) => (
                  <MenuItem key={x.id} value={x.id}>
                    {x.name}
                  </MenuItem>
                ))}
            </Select>
          </div>
        </div>

        {selectedToppingsList && Array.isArray(selectedToppingsList) && selectedToppingsList.map((item) => (
          <Card key={item.id} style={{ padding: "20px 10px", marginBottom: "20px" }}>
            <div style={{ display: "flex", justifyContent: "space-between" }}>
              <div
                style={{
                  height: "50px",
                  verticalAlign: "middle",
                  display: "flex",
                  alignItems: "center",
                  justifyContent: "center",
                }}
              >
                <span>
                  Topping: <b>{item.name}</b>{" "}
                </span>
              </div>
            </div>
          </Card>
        ))}

        <Button2 onClick={addTopping} style={{ marginTop: "2em", width: "30%" }} variant="contained">ADD TOPPING</Button2>

        <hr style={{ marginTop: "1em", width: "100%" }} />

        <Button onClick={() => handleSubmit()} style={{ marginTop: "2em", width: "50%" }} variant="contained">CREATE</Button>

        <hr style={{ marginTop: "1em", width: "100%" }} />
        <div style={{ textAlign: 'center' }}>
          <p style={{ fontSize: '24px' }}>
            Total Pizza Cost: <b>{totalPizzaCost}</b>
          </p>
        </div>
        <hr style={{ marginTop: "1em", width: "100%" }} />
      </Wrapper>

      <ErrorPopup
        open={errorPopupOpen}
        onClose={() => setErrorPopupOpen(false)}
        text={errorPopupMessage}
      />

      <ConfirmationPopup
        open={confirmationPopupOpen}
        onClose={() => setConfirmationPopupOpen(false)}
        onConfirm={addPizzaOrder}
      />
    </Container>
  );
};

export default CreatePizzaOrder;