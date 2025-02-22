import React, { useEffect, useState } from "react";
import axios from "axios";

const AssetTable = () => {
  const [assets, setAssets] = useState([]);
  const [playerId, setPlayerId] = useState("");

  // Hàm để gọi API và lấy dữ liệu
  const fetchAssets = async () => {
    try {
      const response = await axios.get(
        `http://localhost:7071/api/getassetsbyplayer?playerId=${playerId}`
      );
      setAssets(response.data);
    } catch (error) {
      console.error("Error fetching assets:", error);
    }
  };

  // Xử lý khi người dùng nhập PlayerId và nhấn nút
  const handleSearch = () => {
    if (playerId) {
      fetchAssets();
    } else {
      alert("Please enter a Player ID.");
    }
  };

  return (
    <div>
      <h1>Player Assets</h1>
      <div>
        <input
          type="text"
          placeholder="Enter Player ID"
          value={playerId}
          onChange={(e) => setPlayerId(e.target.value)}
        />
        <button onClick={handleSearch}>Search</button>
      </div>
      <table>
        <thead>
          <tr>
            <th>Player Name</th>
            <th>Level</th>
            <th>Age</th>
            <th>Asset Name</th>
          </tr>
        </thead>
        <tbody>
          {assets.map((asset, index) => (
            <tr key={index}>
              <td>{asset.PlayerName}</td>
              <td>{asset.Level}</td>
              <td>{asset.Age}</td>
              <td>{asset.AssetName}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default AssetTable;
