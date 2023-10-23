import React from "react";
import styled from "styled-components";
import { mobile } from "../responsive";
import { useHistory } from 'react-router-dom'
import { Routes } from '../routes'


const Container = styled.div`
  height: 60px;
  ${mobile({ height: "50px" })}
`;

const Wrapper = styled.div`
  padding: 10px 20px;
  display: flex;
  align-items: center;
  justify-content: space-between;
  ${mobile({ padding: "10px 0px" })}
`;

const Left = styled.div`
  flex: 1;
  display: flex;
  align-items: center;
`;

const ShopName = styled.h1`
  font-weight: bold;
  cursor: pointer;
  ${mobile({ fontSize: "24px" })}
`;
const Right = styled.div`
  flex: 1;
  display: flex;
  align-items: center;
  justify-content: flex-end;
  ${mobile({ flex: 2, justifyContent: "center" })}
`;

const MenuItem = styled.div`
  font-size: 14px;
  cursor: pointer;
  margin-left: 50px;
  font-weight: bold;
  text-align: center;
  position: center;
  right: 35%;
  ${mobile({ fontSize: "12px", marginLeft: "10px" })}
`;

const Navbar = () => {
  const history = useHistory()

  return (
    <Container>
      <Wrapper>
        <Left>
          <ShopName onClick={(e) => { history.push(Routes.Home.path) }}>Pizzas</ShopName>
        </Left>
        <Right>
          <MenuItem onClick={(e) => history.push(`${Routes.CreatePizza.path}`)}>Create Pizza</MenuItem>
          <MenuItem onClick={(e) => { history.push(Routes.OrdersList.path) }}>Pizza Orders</MenuItem>
        </Right>
      </Wrapper>
    </Container>
  );
};

export default Navbar;
