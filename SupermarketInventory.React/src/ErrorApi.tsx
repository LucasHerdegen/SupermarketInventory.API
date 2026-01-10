export default function ErrorApi(props: ErrorApiProps)
{
    console.log(props.error);

    return (
      <div className='container'>
        <div className='text-center'>
          <h3> Something went wrong! </h3>
          <p className='text-primary'> Error: {props.error}</p>
        </div>
      </div>
    );
}

interface ErrorApiProps
{
    error: string;
}