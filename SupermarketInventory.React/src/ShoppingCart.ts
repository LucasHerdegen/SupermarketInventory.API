import { createContext } from "react";
import type { Product } from "./producto";

type ShoppingCartContext = {
  cart: Product[];
  addProduct: (p: Product) => void;
  removeProduct: (p: Product) => void;
};

export const ShopingCart = createContext<ShoppingCartContext>({
  cart: [],
  addProduct: () => {},
  removeProduct: () => {},
});