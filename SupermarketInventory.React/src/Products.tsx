import type { Producto } from "./producto";
import Table from "./Table";

export default function Products(props: ProductsProps)
{
    console.table(props.products);

    return (
        <div className='container'>
          <h3 className='text-center text-primary' > Ok! </h3>
          <Table products={props.products} />
        </div> 
    );
}


interface ProductsProps
{
    products: Producto[]
} 