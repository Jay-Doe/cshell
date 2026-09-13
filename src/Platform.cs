namespace Shell.Platform;


public static class Platform
{
    public static List<string>? GetPath()
    {
        string? path = Environment.GetEnvironmentVariable("PATH");
        if (path is null)
        {
            return null;
        }
        List<string> PathAcc = [];
        foreach (string dir in path.Split(Path.PathSeparator))
        {
            PathAcc.Add(dir);
        }
        return PathAcc;

    }
    public static string? FindExe(string name)
    {
        var paths = GetPath();
        if (paths == null)
        {
            return null;
        }
        foreach (var path in paths)
        {
            var candidate = Path.Combine(path, name);
            bool exists = File.Exists(candidate);
            if (!exists)
            {
                continue;
            }
            else
            {
                var p = IsExe(candidate);
                if (p)
                {
                    return candidate;
                }
            }
        }
        return null;
    }
    static bool IsExe(string candidate)
    {
        switch (File.Exists(candidate))
        {
            case false:
                return false;
            case true:
                var mode = File.GetUnixFileMode(candidate);
                return mode.HasFlag(UnixFileMode.UserExecute) || mode.HasFlag(UnixFileMode.GroupExecute) || mode.HasFlag(UnixFileMode.OtherExecute);

        }
    }
}
