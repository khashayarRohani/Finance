import Table from "../../Components/Table/Table";
import RatioList from "../../Components/RatioList/RatioList";
import { testIncomeStatementData } from "../../Components/Table/testData";
import { config } from "dotenv";

type Props = {};
const tableConfig = [
  {
    label: "Market Cap",
    render: (company: any) => company.marketCapTTM,
  },
];
const DesignGuide = (props: Props) => {
  return (
    <>
      <h1>
        Design guide- This is the design guide. These are reuable components of
        the app with brief instructions on how to use them.
      </h1>
      <RatioList data={testIncomeStatementData} config={config} />
      <Table />
      <h3>
        Table - Table takes in a configuration object and company data as
        params. Use the config to style your table.
      </h3>
    </>
  );
};

export default DesignGuide;
