import axios from "axios";

import { handleError } from "../Helpers/ErrorHandler";
import { CommentPost } from "../Components/Models/Comment";
const api = "http://127.0.0.1:5285/api/comment/";

export const commentPostAPI = async (
  title: string,
  content: string,
  symbol: string
) => {
  try {
    const data = await axios.post<CommentPost>(api + `${symbol}`, {
      title: title,
      content: content,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};
