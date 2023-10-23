import axios from "axios";

const API_URL = "http://localhost:5228/api/pizzaorders";

class PizzaOrdersService {
    getMany() {
        return axios.get(API_URL);
    }

    get(pizzaOrderId) {
        return axios.get(API_URL + "/" + pizzaOrderId);
    }

    create(pizzaOrder) {
        return axios.post(API_URL, pizzaOrder);
    }

    delete(pizzaOrderId) {
        return axios.delete(API_URL + "/" + pizzaOrderId);
    }

    calculateTotalOrderCost(pizzaOrder) {
        return axios.post(API_URL + "/calculatetotalcost", pizzaOrder);
    }
}

export default new PizzaOrdersService();
