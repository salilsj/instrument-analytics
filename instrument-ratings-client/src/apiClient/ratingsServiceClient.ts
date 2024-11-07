import { Instrument } from "../viewModels/instrument";
import axios from 'axios'
import config from '../config/appConfig';

// Interfaces should be moved to their own file but keeping here for ease of access and understanding
export interface IRatingsServiceClient {
    fetchInstrumentRating(): Promise<Instrument[]>;
}

export class RatingsServiceClient implements IRatingsServiceClient {
    private readonly baseUrl: string;

    constructor(baseUrl: string = config.apiBaseUrl) {
        this.baseUrl = baseUrl;
    }

    // Method to fetch instruments data from API
    async fetchInstrumentRating(): Promise<Instrument[]> {
        try {
            const response = await axios.get<Instrument[]>(`${this.baseUrl}InstrumentRatings`);
            return response.data;
        } catch (error) {
            console.error("Error fetching instruments data:", error);
            throw error;
        }
    }
}
