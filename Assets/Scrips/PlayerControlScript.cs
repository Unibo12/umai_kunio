using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlScript : MonoBehaviour
{
    // 速度
    public Vector2 SPEED = new Vector2(0.05f, 0.05f);

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームパッドが接続されていないとnullになる。
        if (Gamepad.current == null) return;

        var gamepad = Gamepad.current;

        // 移動処理
        Move();
    }

    // 移動関数
    void Move()
    {
        // 現在位置をPositionに代入
        Vector2 Position = transform.position;

        // 左キーを押し続けていたら
        if (
            Gamepad.current.leftStick.ReadValue().x < 0 ||
            Gamepad.current.dpad.left.IsPressed()
        )
        {
            // 代入したPositionに対して加算減算を行う
            Position.x -= SPEED.x;
        }
        else if (
            0 < Gamepad.current.leftStick.ReadValue().x ||
            Gamepad.current.dpad.right.IsPressed()
        )
        {
            // 右キーを押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.x += SPEED.x;
        }
        
        // if (
        //     Gamepad.current.leftStick.ReadValue().y < 0 ||
        //     Gamepad.current.dpad.up.IsPressed()
        // )
        // {
        //     // 上キーを押し続けていたら
        //     // 代入したPositionに対して加算減算を行う
        //     Position.y += SPEED.y;
        // }
        // else if (
        //     0 < Gamepad.current.leftStick.ReadValue().y ||
        //     Gamepad.current.dpad.down.IsPressed()
        // )
        // {
        //     // 下キーを押し続けていたら
        //     // 代入したPositionに対して加算減算を行う
        //     Position.y -= SPEED.y;
        // }

        // 現在の位置に加算減算を行ったPositionを代入する
        transform.position = Position;
    }
}
