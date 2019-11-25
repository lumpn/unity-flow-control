# unity-flow-control
Flow control loop

## Properties

- `I` in-flow in units per second (varies)
- `O` out-flow in units per second (controlled)
- `B` buffer in units
- `r` buffer drain rate in 1/s (configurable)

```
B(t1) = B(t0) + integral_t0_t1 (I(t) - O(t)) dt;

I = const -> O = I
I = 0 -> O = B / r

O = pI + qB -> p = 1, q = 1/r
```
