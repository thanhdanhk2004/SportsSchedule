import { endpoints, authApis } from "../../Services/Apis";


const ManagerSeason = () => {

  const handleAddSeason = async () => {
    try {
      const response = await authApis().post(endpoints.addSeason);
      if(response.status === 200)
        alert("Thêm mùa giải thành công");
    } catch (error) {
      alert("Mùa giải hiện tại đã có rồi");
    }
  }

  return (
    <div>
      <div className="btn btn-primary" style={{ marginBottom: "460px", marginTop: "30px", marginLeft: "30px", width: "200px", height: "50px" }} onClick={handleAddSeason}>
        Thêm mùa giải mới
      </div>
    </div>
  );
};

export default ManagerSeason;