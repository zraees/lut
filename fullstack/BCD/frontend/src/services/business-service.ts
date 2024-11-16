import axios from "axios";
import { IBusiness } from "../types/types";
const backendUrl = import.meta.env.VITE_BCD_BACKEND_URL;

const BusinessService = {
    getBusinesses : async () : Promise<IBusiness[]> => {
        const resp = await axios.get<IBusiness[]>(`${backendUrl}Businesses/GetAllBusinesses`);
        return resp.data;
    }, 
    
    getFeatureBusinesses : async () : Promise<IBusiness[]> => {
        const resp = await axios.get<IBusiness[]>(`${backendUrl}Businesses/GetFeatureBusinesses`);
        //console.log('url', `${backendUrl}Businesses/GetFeatureBusinesses`)
        return resp.data;
    } 
}

export default BusinessService;