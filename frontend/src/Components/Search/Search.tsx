import React, { SyntheticEvent } from "react";

type Props = {
  search: string | undefined;
  handleSearchChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  onSearchSubmit: (e: SyntheticEvent) => void;
};

const Search: React.FC<Props> = (props: Props): JSX.Element => {
  return (
    <>
      <form onSubmit={props.onSearchSubmit}>
        <input
          value={props.search}
          onChange={(e) => props.handleSearchChange(e)}
        />
      </form>
    </>
  );
};

export default Search;
