using Npgsql;
using System.Data;

namespace cosmic_management_api.Models {
    public class Database {
        public Response loginUser(NpgsqlConnection con, User user) {
            con.Open();
            Response response = new Response();
            string Query = string.Format("SELECT * FROM users WHERE username='{0}' AND password='{1}'", user.Username, user.Password);

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count > 0) {
                response.status = 200;
                response.message = "Logged in successfully";
                response.body = user;
                response.data = null;
            }
            else {
                response.status = 500;
                response.message = "Failed to login";
                response.body = null;
                response.data = null;
            }
            con.Close();
            return response;
        }

    }
}
