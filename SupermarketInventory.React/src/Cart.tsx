import { useContext } from "react";
import Table from "./Table";
import { ShopingCart } from './ShoppingCart';

export default function Cart()
{
    const { cart } = useContext(ShopingCart);

    if (cart.length > 0)
        return (
            <>
                <div className="container">
                    <h3 className='text-center text-success'> Cart </h3> <br />
                    <Table products={cart} target="cart" showQuantity={true}/>
                </div>
            </>
        );
}