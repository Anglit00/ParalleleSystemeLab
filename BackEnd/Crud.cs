namespace Backend
{
    public class Crud
    {
        private readonly string _connectionString;
        private DataAccess db = new();

        public Crud(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateFood(FoodModel p)
        {
            string sql = "INSERT INTO dbo.Food (Name, DangerLevel, MoreInfo) VALUES (@Name, @DangerLevel, @MoreInfo);";
            db.SaveData(sql, new { p.Name, p.DangerLevel, p.MoreInfo }, _connectionString);
        }

        public void DeleteFood(int ID)
        {
            string sql = "DELETE FROM dbo.Food WHERE ID = @ID;";
            db.SaveData(sql, new { ID }, _connectionString);
        }

        public List<FoodModel> GetAllFood()
        {
            string sql = "SELECT * FROM dbo.Food;";
            return db.LoadData<FoodModel,dynamic>(sql, new { } , _connectionString);
        }

        public void UpdateFood(FoodModel p)
        {
            string sql = "UPDATE dbo.Food SET Name = @Name, DangerLevel = @DangerLevel, MoreInfo = @MoreInfo WHERE ID = @ID;";
            db.SaveData(sql, new { p.Name, p.DangerLevel, p.MoreInfo, p.Id }, _connectionString);
        }

        public FoodModel GetFoodById(int id)
        {
            string sql = "SELECT * FROM dbo.Food WHERE ID = @ID;";
            var parameters = new { ID = id };

            var result = db.LoadData<FoodModel, dynamic>(sql, parameters, _connectionString);

            return result.Count > 0 ? result[0] : null;
        }
    }
}
