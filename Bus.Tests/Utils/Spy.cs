namespace Bus.Tests.Utils;

public class Spy
{
    public int Invocations { get; private set; } = 0;

    public void Callable()
    {
        Invocations += 1;
    }

    public void VerifyCalled() => Assert.True(Invocations > 0);
    public void VerifyCalled(int times) => Assert.Equal(times, Invocations);
    public void VerifyCalledOnce() => Assert.Equal(1, Invocations);
    public void VerifyNotCalled() => Assert.Equal(0, Invocations);
}
