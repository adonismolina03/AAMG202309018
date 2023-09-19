namespace AAMG202309018.Endpoints
{
    public static class BodegaEndpoint
    {
        static List<object> data = new List<object>();
        public static void AddBodegaEndpoints(this WebApplication app)
        {
            app.MapPost("/bodega", ( string producto) =>
            {
                data.Add(new { producto });
                return Results.Ok();
            }).AllowAnonymous();

            app.MapGet("/bodega/{id}", (int id) =>
            {
                if (id >= 0 && id < data.Count)
                {
                    var producto = data[id];
                    return Results.Ok(producto);
                }
                else
                {
                    return Results.NotFound();
                }
            }).AllowAnonymous();

            app.MapPut("/bodega/{id}", (int id, string producto) =>
            {
                if (id >= 0 && id < data.Count)
                {
                    data[id] = new { producto };
                    return Results.Ok();
                }
                else
                {
                    return Results.NotFound();
                }
            }).AllowAnonymous();
        }
    }
}
