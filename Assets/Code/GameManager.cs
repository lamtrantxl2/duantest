using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0; // Tổng điểm của người chơi.
    public int playerHealth = 100; // Máu của người chơi.
    public int enemyAttackDamage = 15; // Sát thương của kẻ địch.

    /// <summary>
    /// Cộng thêm điểm vào tổng điểm hiện tại.
    /// </summary>
    /// <param name="points">Số điểm cần cộng thêm.</param>
    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Điểm hiện tại: " + score);
    }

    /// <summary>
    /// Giảm máu của người chơi khi bị tấn công.
    /// </summary>
    /// <param name="damage">Số máu cần giảm.</param>
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        playerHealth = Mathf.Max(playerHealth, 0); // Đảm bảo máu không âm.
        Debug.Log("Máu hiện tại: " + playerHealth);

        if (IsPlayerDead())
        {
            Debug.Log("Người chơi đã chết!");
        }
    }

    /// <summary>
    /// Kiểm tra xem người chơi có chết không.
    /// </summary>
    /// <returns>True nếu máu bằng 0, ngược lại False.</returns>
    public bool IsPlayerDead()
    {
        return playerHealth <= 0;
    }

    /// <summary>
    /// Kẻ địch gây sát thương lên người chơi.
    /// </summary>
    public void EnemyAttack()
    {
        TakeDamage(enemyAttackDamage);
        Debug.Log("Kẻ địch gây " + enemyAttackDamage + " sát thương.");
    }

    /// <summary>
    /// Lấy tổng điểm hiện tại.
    /// </summary>
    /// <returns>Giá trị tổng điểm.</returns>
    public int GetScore()
    {
        return score;
    }

    /// <summary>
    /// Lấy máu hiện tại của người chơi.
    /// </summary>
    /// <returns>Giá trị máu hiện tại.</returns>
    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    // Kiểm tra đầu vào bàn phím.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) // Nhấn phím A để cộng điểm.
        {
            AddScore(10); // Cộng 10 điểm.
        }

        if (Input.GetKeyDown(KeyCode.S)) // Nhấn phím S để trừ máu.
        {
            TakeDamage(20); // Giảm 20 máu.
        }

        if (Input.GetKeyDown(KeyCode.D)) // Nhấn phím D để kẻ địch tấn công.
        {
            EnemyAttack(); // Gây sát thương.
        }
    }
}

