import React, { useState, SyntheticEvent, useEffect } from "react";
import { searchCompanies } from "../../api";
import { CompanySearch } from "../../company";
import Search from "../../Components/Search/Search";
import ListPortfolio from "../../Components/Portfolio/ListPortfolio/ListPortfolio";
import CardList from "../../Components/CardList/CardList";
import { PortfolioGet } from "../../Components/Models/Portfolio";
import {
  portfolioAddAPI,
  portfolioDeleteAPI,
  portfolioGetAPI,
} from "../../Services/PortfolioService";
import { toast } from "react-toastify";

type Props = {};

const SearchPage = (props: Props) => {
  const [search, setSearch] = useState<string>("");
  const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const [serverError, setServerError] = useState<string>("");
  const [portfolioValues, setPortfolioValues] = useState<PortfolioGet[] | null>(
    []
  );
  useEffect(() => {
    getPortfolio();
  }, []);
  const onSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    const result = await searchCompanies(search);
    if (typeof result === "string") {
      setServerError(result);
    } else if (Array.isArray(result.data)) {
      setSearchResult(result.data);
    }
    console.log(searchResult);
  };
  const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    console.log(e.target.value);
    setSearch(e.target.value);
  };
  const getPortfolio = () => {
    portfolioGetAPI()
      .then((res) => {
        if (res?.data) {
          setPortfolioValues(res?.data);
        }
      })
      .catch((e) => {
        setPortfolioValues(null);
      });
  };
  const onPortfolioCreate = (e: any) => {
    e.preventDefault();
    portfolioAddAPI(e.target[0].value)
      .then((res) => {
        if (res?.status === 204) {
          toast.success("Stock added to portfolio!");
          getPortfolio();
        }
      })
      .catch((e) => {
        toast.warning("Could not add stock to portfolio!");
      });
  };
  const onPortfolioDelete = (e: any) => {
    e.preventDefault();
    portfolioDeleteAPI(e.target[0].value).then((res) => {
      if (res?.status == 200) {
        toast.success("Stock deleted from portfolio!");
        getPortfolio();
      }
    });
  };
  return (
    <div>
      <Search
        onSearchSubmit={onSearchSubmit}
        handleSearchChange={handleSearchChange}
        search={search}
      />
      {serverError && <h1>{serverError}</h1>}
      <ListPortfolio
        portfolioValues={portfolioValues!}
        onPortfolioDelete={onPortfolioDelete}
      />
      <CardList
        onPortfolioCreate={onPortfolioCreate}
        searchResults={searchResult}
      />
    </div>
  );
};

export default SearchPage;
