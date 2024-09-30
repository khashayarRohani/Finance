import axios from "axios";
import {
  CompanyIncomeStatement,
  CompanyKeyMetrix,
  CompanyProfile,
  CompanySearch,
} from "./company";

interface SearchResponse {
  data: CompanySearch[];
}
export const searchCompanies = async (query: string) => {
  try {
    const data = await axios.get<SearchResponse>(
      `https://financialmodelingprep.com/api/v3/search-ticker?query=${query}&limit=10&exchange=NASDAQ&apikey=${
        import.meta.env.VITE_REACT_APP_API_KEY
      }`
    );
    return data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.log("error message: ", error.message);
      return error.message;
    } else {
      console.log("unexpected error: ", error);
      return "An expected error has occured.";
    }
  }
};
export const getCompanyProfile = async (query: string) => {
  try {
    const data = await axios.get<CompanyProfile>(
      `https://financialmodelingprep.com/api/v3/profile/${query}?apikey=${
        import.meta.env.VITE_REACT_APP_API_KEY
      }`
    );
    return data;
  } catch (error: any) {
    console.log("error message from API: ", error.message);
  }
};
export const getKeyMatrix = async (query: string) => {
  try {
    const data = await axios.get<CompanyKeyMetrix>(
      `https://financialmodelingprep.com/api/v3/key-metrics-ttm/${query}?limit=40&apikey=${
        import.meta.env.VITE_REACT_APP_API_KEY
      }`
    );

    return data;
  } catch (error: any) {
    console.log("error message from API: ", error.message);
  }
};
export const getIncomeStatement = async (query: string) => {
  try {
    const data = await axios.get<CompanyIncomeStatement[]>(
      `https://financialmodelingprep.com/api/v3/income-statement/${query}?limit=40&apikey=${
        import.meta.env.VITE_REACT_APP_API_KEY
      }`
    );
    return data;
  } catch (error: any) {
    console.log("error message: ", error.message);
  }
};
export const getBalanceSheet = async (query: string) => {
  try {
    const data = await axios.get<CompanyBalanceSheet[]>(
      `https://financialmodelingprep.com/api/v3/balance-sheet-statement/${query}?limit=20&apikey=${
        import.meta.env.VITE_REACT_APP_API_KEY
      }`
    );
    return data;
  } catch (error: any) {
    console.log("error message: ", error.message);
  }
};
