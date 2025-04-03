using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    private GameManager gameManager;
    [SetUp]
    public void Setup()
    {
        // Khởi tạo GameManager nếu cần
        gameManager = new GameObject().AddComponent<GameManager>();
    }
    
    // A Test behaves as an ordinary method
// Test: Cộng điểm
    [Test]
    public void AddScoreTest()
    {
        // Arrange: Cộng 10 điểm.
        int initialScore = gameManager.GetScore();
        int pointsToAdd = 15;

        // Act: Gọi hàm AddScore.
        gameManager.AddScore(pointsToAdd);

        // Assert: Điểm phải tăng đúng giá trị.
        Assert.AreEqual(initialScore + pointsToAdd  , gameManager.GetScore(), "Điểm không tăng đúng.");
    }

    // Test: Giảm máu
    [Test]
    public void TakeDamageTest()
    {
        // Arrange: Máu ban đầu.
        int initialHealth = gameManager.GetPlayerHealth();
        int damage = 20;

        // Act: Gọi hàm TakeDamage.
        gameManager.TakeDamage(damage);

        // Assert: Máu phải giảm đúng giá trị.
        Assert.AreEqual(initialHealth - damage, gameManager.GetPlayerHealth(), "Máu không giảm đúng.");
    }

    // Test: Kẻ địch gây sát thương
    [Test]
    public void EnemyAttackTest()
    {
        // Arrange: Máu ban đầu.
        int initialHealth = gameManager.GetPlayerHealth();
        int expectedDamage = 15; // Giá trị mặc định của sát thương kẻ địch.
        // Act: Gọi hàm EnemyAttack.
        gameManager.EnemyAttack();

        // Assert: Máu phải giảm đúng giá trị sát thương của kẻ địch.
        Assert.AreEqual(initialHealth - expectedDamage , gameManager.GetPlayerHealth(), "Sát thương không chính xác.");
    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
   // [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
