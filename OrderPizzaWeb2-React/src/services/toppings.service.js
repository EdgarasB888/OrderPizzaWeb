import axios from "axios";

const API_URL = "http://localhost:5228/api/toppings";

class ToppingsService {
    getMany() {
        return axios.get(API_URL);
    }

    get(toppingId) {
        return axios.get(API_URL + "/" + toppingId);
    }
}

export default new ToppingsService();