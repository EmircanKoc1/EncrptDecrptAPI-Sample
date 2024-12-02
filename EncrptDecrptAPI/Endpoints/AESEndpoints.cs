namespace EncrptDecrptAPI.Endpoints
{
    public static class AESEndpoints
    {

        public static void MapAESEndpoints(this WebApplication app)
        {

            app.MapGet("encrpt", () =>
            {

            });


            app.MapGet("decrpt", () =>
            {

            });


        }



    }
}
